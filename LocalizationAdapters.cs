using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Threading;
using HarmonyLib;

namespace LoadTimeProfiler;

internal abstract class LocalizationAdapterBase
{
    private int _disabled;

    protected LocalizationAdapterBase(MethodInfo target)
    {
        Target = target;
    }

    internal MethodInfo Target { get; }
    internal bool Disabled => Volatile.Read(ref _disabled) != 0;

    internal bool ValidateCompatibility()
    {
        if (Disabled)
        {
            return false;
        }

        if (LocalizationAdapterRegistry.HasForeignPatches(Target))
        {
            Disable("the producer method has foreign Harmony patches");
            return false;
        }

        return true;
    }

    internal void Disable(string reason)
    {
        if (Interlocked.Exchange(ref _disabled, 1) != 0)
        {
            return;
        }

        ProfilerLog.WriteWarning(
            "Localization adapter disabled fail-open for " +
            LocalizationAdapterRegistry.FormatMethod(Target) +
            ": " +
            reason +
            ".");
    }
}

internal sealed class ParsedMapCallState
{
    private readonly ParsedMapLocalizationAdapter _adapter;
    private readonly string _language;

    internal ParsedMapCallState(
        ParsedMapLocalizationAdapter adapter,
        string language)
    {
        _adapter = adapter;
        _language = language;
    }

    private bool Completed { get; set; }

    internal void Complete(bool succeeded)
    {
        if (Completed)
        {
            return;
        }

        Completed = true;
        _adapter.CompleteOriginal(_language, succeeded);
    }

    internal void Fail(string reason)
    {
        _adapter.Disable(reason);
        Complete(succeeded: false);
    }
}

internal sealed class ParsedMapLocalizationAdapter :
    LocalizationAdapterBase
{
    private static readonly Type LoadedTextsType =
        typeof(Dictionary<string, Dictionary<string, string>>);
    private static readonly Type PlaceholderProcessorsType =
        typeof(Dictionary<string, Dictionary<string, Func<string>>>);
    private static readonly Type LocalizationLanguageType =
        typeof(ConditionalWeakTable<Localization, string>);
    private static readonly Type LocalizationObjectsType =
        typeof(List<WeakReference<Localization>>);

    private readonly object _lock = new();
    private readonly FieldInfo _loadedTextsField;
    private readonly FieldInfo _localizationLanguageField;
    private readonly FieldInfo _localizationObjectsField;
    private readonly Action<Localization, string> _updatePlaceholderText;
    private readonly HashSet<string> _readyLanguages =
        new(StringComparer.Ordinal);

    private ParsedMapLocalizationAdapter(
        MethodInfo target,
        FieldInfo loadedTextsField,
        FieldInfo localizationLanguageField,
        FieldInfo localizationObjectsField,
        Action<Localization, string> updatePlaceholderText)
        : base(target)
    {
        _loadedTextsField = loadedTextsField;
        _localizationLanguageField = localizationLanguageField;
        _localizationObjectsField = localizationObjectsField;
        _updatePlaceholderText = updatePlaceholderText;
    }

    internal static bool TryCreate(
        Type type,
        out ParsedMapLocalizationAdapter? adapter)
    {
        adapter = null;

        if (type == null ||
            !string.Equals(type.Name, "Localizer", StringComparison.Ordinal))
        {
            return false;
        }

        const BindingFlags staticDeclared =
            BindingFlags.Static |
            BindingFlags.Public |
            BindingFlags.NonPublic |
            BindingFlags.DeclaredOnly;
        MethodInfo? target = type.GetMethod(
            "LoadLocalization",
            staticDeclared,
            binder: null,
            types: new[] { typeof(Localization), typeof(string) },
            modifiers: null);
        if (target == null || target.ReturnType != typeof(void))
        {
            // Several libraries use the name Localizer without implementing
            // the parsed-map helper. They are not errors or candidates.
            return false;
        }

        MethodInfo? updater = type.GetMethod(
            "UpdatePlaceholderText",
            staticDeclared,
            binder: null,
            types: new[] { typeof(Localization), typeof(string) },
            modifiers: null);
        FieldInfo[] fields = type.GetFields(staticDeclared);
        FieldInfo? loadedTexts = FindSemanticField(
            fields,
            "loadedTexts",
            LoadedTextsType);
        FieldInfo? placeholderProcessors = FindSemanticField(
            fields,
            "PlaceholderProcessors",
            PlaceholderProcessorsType);
        FieldInfo? localizationLanguage = FindSemanticField(
            fields,
            "localizationLanguage",
            LocalizationLanguageType);
        FieldInfo? localizationObjects = FindSemanticField(
            fields,
            "localizationObjects",
            LocalizationObjectsType);

        if (updater == null ||
            updater.ReturnType != typeof(void) ||
            loadedTexts == null ||
            placeholderProcessors == null ||
            localizationLanguage == null ||
            localizationObjects == null)
        {
            return false;
        }

        // Locked/custom variants can maintain extra state that a map replay
        // cannot reproduce. This deliberately excludes the known
        // ValheimEnchantmentSystem extension and similarly evolved forks.
        if (fields.Any(field => field.FieldType == typeof(object)))
        {
            return false;
        }

        if (!LocalizationIlInspector.CallsBestEffort(
                target,
                updater) ||
            !LocalizationIlInspector
                .CallsLocalizationAddWordBestEffort(updater) ||
            !LocalizationIlInspector
                .CallsDirectoryFileEnumerationBestEffort(target) ||
            LocalizationIlInspector
                .CallsDelegateInvokeBestEffort(target))
        {
            return false;
        }

        try
        {
            Action<Localization, string> update =
                (Action<Localization, string>)updater.CreateDelegate(
                    typeof(Action<Localization, string>));
            adapter = new ParsedMapLocalizationAdapter(
                target,
                loadedTexts,
                localizationLanguage,
                localizationObjects,
                update);
            return true;
        }
        catch
        {
            return false;
        }
    }

    internal bool Before(
        Localization instance,
        string language,
        out ParsedMapCallState? state)
    {
        state = null;
        if (Disabled ||
            !LocalizationAdapterRegistry.IsStartupScopeActive ||
            instance == null ||
            string.IsNullOrEmpty(language) ||
            !ValidateCompatibility())
        {
            return true;
        }

        bool ready;
        lock (_lock)
        {
            ready = _readyLanguages.Contains(language);
        }

        if (!ready)
        {
            state = new ParsedMapCallState(this, language);
            return true;
        }

        try
        {
            if (_loadedTextsField.GetValue(null) is not
                    Dictionary<string, Dictionary<string, string>>
                    loadedTexts ||
                !loadedTexts.TryGetValue(
                    language,
                    out Dictionary<string, string>? translations) ||
                _localizationLanguageField.GetValue(null) is not
                    ConditionalWeakTable<Localization, string>
                    localizationLanguage ||
                _localizationObjectsField.GetValue(null) is not
                    List<WeakReference<Localization>>
                    localizationObjects)
            {
                lock (_lock)
                {
                    _readyLanguages.Remove(language);
                }

                state = new ParsedMapCallState(this, language);
                return true;
            }

            bool hadPrevious =
                localizationLanguage.TryGetValue(
                    instance,
                    out string? previousLanguage);
            WeakReference<Localization>? addedReference = null;
            try
            {
                localizationLanguage.Remove(instance);
                if (!hadPrevious)
                {
                    addedReference =
                        new WeakReference<Localization>(instance);
                    localizationObjects.Add(addedReference);
                }

                localizationLanguage.Add(instance, language);
                string[] keys = translations.Keys.ToArray();
                foreach (string key in keys)
                {
                    _updatePlaceholderText(instance, key);
                }

                return false;
            }
            catch
            {
                // Restore the manager's side table before allowing the
                // original method to run. Any partially added words are
                // overwritten by the original loader.
                localizationLanguage.Remove(instance);
                if (hadPrevious && previousLanguage != null)
                {
                    localizationLanguage.Add(
                        instance,
                        previousLanguage);
                }

                if (addedReference != null)
                {
                    localizationObjects.Remove(addedReference);
                }

                throw;
            }
        }
        catch (Exception ex)
        {
            Disable(
                "cached parsed-map replay failed: " +
                ex.GetBaseException().Message);
            return true;
        }
    }

    internal void CompleteOriginal(
        string language,
        bool succeeded)
    {
        if (!succeeded || Disabled)
        {
            return;
        }

        try
        {
            if (_loadedTextsField.GetValue(null) is
                    Dictionary<string, Dictionary<string, string>>
                    loadedTexts &&
                loadedTexts.ContainsKey(language))
            {
                lock (_lock)
                {
                    _readyLanguages.Add(language);
                }
            }
        }
        catch (Exception ex)
        {
            Disable(
                "the original loader result could not be validated: " +
                ex.GetBaseException().Message);
        }
    }

    internal void ClearStartupCache()
    {
        lock (_lock)
        {
            _readyLanguages.Clear();
        }
    }

    private static FieldInfo? FindSemanticField(
        IEnumerable<FieldInfo> fields,
        string name,
        Type fieldType)
    {
        return fields.SingleOrDefault(field =>
            field.FieldType == fieldType &&
            string.Equals(
                field.Name,
                name,
                StringComparison.OrdinalIgnoreCase));
    }
}

internal sealed class LocalizationProducerCallState
{
    internal LocalizationProducerCallState(
        CapturedLocalizationAdapter adapter,
        Localization instance,
        string language,
        long generation)
    {
        Adapter = adapter;
        Instance = instance;
        Language = language;
        Generation = generation;
        if (!LocalizationAcceleration.TryGetTranslations(
                instance,
                out Dictionary<string, string>? beforeDictionary) ||
            beforeDictionary == null)
        {
            throw new InvalidOperationException(
                "Localization.m_translations is unavailable");
        }

        BeforeDictionary = beforeDictionary;
    }

    internal CapturedLocalizationAdapter Adapter { get; }
    internal Localization Instance { get; }
    internal string Language { get; }
    internal long Generation { get; }
    internal Dictionary<string, string> BeforeDictionary { get; }
    internal List<LocalizationAcceleration.WriteOperation> Writes { get; } =
        new();
    internal bool Completed { get; set; }
}

internal abstract class CapturedLocalizationAdapter :
    LocalizationAdapterBase
{
    private readonly object _lock = new();
    private readonly Dictionary<string, CapturedEntry> _entries =
        new(StringComparer.Ordinal);
    private long _generation;

    protected CapturedLocalizationAdapter(
        MethodInfo target,
        MethodBase[] mutationMethods)
        : base(target)
    {
        MutationMethods = mutationMethods;
    }

    internal MethodBase[] MutationMethods { get; }

    internal bool Before(
        Localization instance,
        string language,
        out LocalizationProducerCallState? state)
    {
        state = null;
        if (Disabled ||
            !LocalizationAdapterRegistry.IsStartupScopeActive ||
            instance == null ||
            language == null ||
            !ValidateCompatibility())
        {
            return true;
        }

        if (!LocalizationAcceleration.CanReplayDirectWrites() ||
            !CanCacheCurrentGeneration())
        {
            return true;
        }

        long generation;
        try
        {
            lock (_lock)
            {
                generation = _generation;
                _entries.TryGetValue(
                    language,
                    out CapturedEntry? entry);
                if (entry != null &&
                    entry.Generation == generation)
                {
                    if (!LocalizationAcceleration.TryGetTranslations(
                            instance,
                            out Dictionary<string, string>? translations) ||
                        translations == null)
                    {
                        throw new InvalidOperationException(
                            "Localization.m_translations is unavailable");
                    }

                    foreach (
                        LocalizationAcceleration.WriteOperation write in
                        entry.Writes)
                    {
                        translations.Remove(write.Key);
                        translations.Add(write.Key, write.Value);
                    }

                    return false;
                }
            }
        }
        catch (Exception ex)
        {
            Disable(
                "captured translation replay failed: " +
                ex.GetBaseException().Message);
            return true;
        }

        try
        {
            state = new LocalizationProducerCallState(
                this,
                instance,
                language,
                generation);
            return true;
        }
        catch (Exception ex)
        {
            Disable(
                "translation capture could not start: " +
                ex.GetBaseException().Message);
            state = null;
            return true;
        }
    }

    internal void Complete(
        LocalizationProducerCallState state,
        bool succeeded)
    {
        if (!succeeded ||
            Disabled ||
            !LocalizationAcceleration.TryGetTranslations(
                state.Instance,
                out Dictionary<string, string>? currentDictionary) ||
            !ReferenceEquals(currentDictionary, state.BeforeDictionary))
        {
            return;
        }

        lock (_lock)
        {
            if (state.Generation != _generation)
            {
                return;
            }

            _entries[state.Language] = new CapturedEntry(
                state.Generation,
                state.Writes.ToArray());
        }
    }

    internal void Invalidate()
    {
        lock (_lock)
        {
            _generation++;
            _entries.Clear();
            OnInvalidated();
        }
    }

    internal void ClearStartupCache()
    {
        lock (_lock)
        {
            _entries.Clear();
        }
    }

    protected virtual bool CanCacheCurrentGeneration()
    {
        return true;
    }

    protected virtual void OnInvalidated()
    {
    }

    private sealed class CapturedEntry
    {
        internal CapturedEntry(
            long generation,
            LocalizationAcceleration.WriteOperation[] writes)
        {
            Generation = generation;
            Writes = writes;
        }

        internal long Generation { get; }
        internal LocalizationAcceleration.WriteOperation[] Writes { get; }
    }
}

internal sealed class LocalizeKeyLocalizationAdapter :
    CapturedLocalizationAdapter
{
    private readonly object _aliasLock = new();
    private readonly FieldInfo _keysField;
    private readonly FieldInfo _localizationsField;
    private bool _aliasStateKnown;
    private bool _containsAlias;

    private LocalizeKeyLocalizationAdapter(
        MethodInfo target,
        MethodBase[] mutationMethods,
        FieldInfo keysField,
        FieldInfo localizationsField)
        : base(
            target,
            mutationMethods)
    {
        _keysField = keysField;
        _localizationsField = localizationsField;
    }

    internal static bool TryCreate(
        MethodInfo target,
        out LocalizeKeyLocalizationAdapter? adapter)
    {
        adapter = null;
        Type? type = target.DeclaringType;
        if (type == null ||
            !string.Equals(
                type.Name,
                "LocalizeKey",
                StringComparison.Ordinal) ||
            !IsKnownManagerLocalizeKey(type) ||
            !string.Equals(
                target.Name,
                "AddLocalizedKeys",
                StringComparison.Ordinal) ||
            !target.IsStatic ||
            target.ReturnType != typeof(void))
        {
            return false;
        }

        ParameterInfo[] parameters = target.GetParameters();
        if (parameters.Length != 2 ||
            parameters[0].ParameterType != typeof(Localization) ||
            parameters[1].ParameterType != typeof(string) ||
            !LocalizationIlInspector.CallsLocalizationAddWord(target) ||
            LocalizationIlInspector.CallsDelegateInvoke(target) ||
            !LocalizationIlInspector.HasCanonicalLocalizeKeyBody(target))
        {
            return false;
        }

        const BindingFlags allDeclared =
            BindingFlags.Instance |
            BindingFlags.Static |
            BindingFlags.Public |
            BindingFlags.NonPublic |
            BindingFlags.DeclaredOnly;
        FieldInfo? keysField = type.GetFields(allDeclared)
            .SingleOrDefault(field =>
                field.IsStatic &&
                string.Equals(
                    field.Name,
                    "keys",
                    StringComparison.OrdinalIgnoreCase) &&
                field.FieldType.IsGenericType &&
                field.FieldType.GetGenericTypeDefinition() ==
                typeof(List<>) &&
                field.FieldType.GetGenericArguments()[0] == type);
        FieldInfo? localizationsField = type.GetFields(allDeclared)
            .SingleOrDefault(field =>
                !field.IsStatic &&
                string.Equals(
                    field.Name,
                    "Localizations",
                    StringComparison.Ordinal) &&
                field.FieldType ==
                typeof(Dictionary<string, string>));
        MethodInfo? addForLang = type.GetMethod(
            "addForLang",
            allDeclared,
            binder: null,
            types: new[] { typeof(string), typeof(string) },
            modifiers: null);
        MethodInfo? alias = type.GetMethod(
            "Alias",
            allDeclared,
            binder: null,
            types: new[] { typeof(string) },
            modifiers: null);
        ConstructorInfo? constructor = type.GetConstructor(
            allDeclared,
            binder: null,
            types: new[] { typeof(string) },
            modifiers: null);
        if (keysField == null ||
            localizationsField == null ||
            addForLang == null ||
            addForLang.IsStatic ||
            addForLang.ReturnType != type ||
            alias == null ||
            alias.IsStatic ||
            alias.ReturnType != typeof(void) ||
            constructor == null)
        {
            return false;
        }

        adapter = new LocalizeKeyLocalizationAdapter(
            target,
            new MethodBase[] { constructor, addForLang, alias },
            keysField,
            localizationsField);
        return true;
    }

    protected override bool CanCacheCurrentGeneration()
    {
        lock (_aliasLock)
        {
            if (_aliasStateKnown)
            {
                return !_containsAlias;
            }

            try
            {
                _containsAlias = ContainsAlias();
                _aliasStateKnown = true;
                return !_containsAlias;
            }
            catch (Exception ex)
            {
                Disable(
                    "LocalizeKey alias state could not be validated: " +
                    ex.GetBaseException().Message);
                return false;
            }
        }
    }

    protected override void OnInvalidated()
    {
        lock (_aliasLock)
        {
            _aliasStateKnown = false;
            _containsAlias = false;
        }
    }

    private bool ContainsAlias()
    {
        if (_keysField.GetValue(null) is not IEnumerable keys)
        {
            throw new InvalidOperationException(
                "LocalizeKey keys registry is unavailable");
        }

        foreach (object? key in keys)
        {
            if (key != null &&
                _localizationsField.GetValue(key) is
                    Dictionary<string, string> localizations &&
                localizations.ContainsKey("alias"))
            {
                return true;
            }
        }

        return false;
    }

    private static bool IsKnownManagerLocalizeKey(Type type)
    {
        string fullName = type.FullName ?? string.Empty;
        return string.Equals(
                   fullName,
                   "ItemManager.LocalizeKey",
                   StringComparison.Ordinal) ||
               string.Equals(
                   fullName,
                   "PieceManager.LocalizeKey",
                   StringComparison.Ordinal) ||
               string.Equals(
                   fullName,
                   "CreatureManager.LocalizeKey",
                   StringComparison.Ordinal) ||
               string.Equals(
                   fullName,
                   "StatusEffectManager.LocalizeKey",
                   StringComparison.Ordinal) ||
               string.Equals(
                   fullName,
                   "SkillManager.Skill+LocalizeKey",
                   StringComparison.Ordinal);
    }
}

internal static class LocalizationIlInspector
{
    private static readonly OpCode[] SingleByteOpCodes =
        new OpCode[0x100];
    private static readonly OpCode[] MultiByteOpCodes =
        new OpCode[0x100];

    static LocalizationIlInspector()
    {
        foreach (
            FieldInfo field in typeof(OpCodes).GetFields(
                BindingFlags.Public | BindingFlags.Static))
        {
            if (field.GetValue(null) is not OpCode opcode)
            {
                continue;
            }

            ushort value = unchecked((ushort)opcode.Value);
            if (value < 0x100)
            {
                SingleByteOpCodes[value] = opcode;
            }
            else if ((value & 0xff00) == 0xfe00)
            {
                MultiByteOpCodes[value & 0xff] = opcode;
            }
        }
    }

    internal static bool Calls(
        MethodInfo method,
        MethodBase target)
    {
        return TryInspect(
                   method,
                   out MethodBase[] calls,
                   out _) &&
               calls.Any(called =>
                   SameMethod(called, target));
    }

    internal static bool CallsBestEffort(
        MethodInfo method,
        MethodBase target)
    {
        return TryInspect(
                   method,
                   out MethodBase[] calls,
                   out _,
                   allowUnresolvedMethods: true) &&
               calls.Any(called =>
                   SameMethod(called, target));
    }

    internal static bool CallsLocalizationAddWord(MethodInfo method)
    {
        return TryInspect(
                   method,
                   out MethodBase[] calls,
                   out _) &&
               calls.Any(called =>
        {
            if (called.DeclaringType != typeof(Localization) ||
                !string.Equals(
                    called.Name,
                    "AddWord",
                    StringComparison.Ordinal))
            {
                return false;
            }

            ParameterInfo[] parameters = called.GetParameters();
            return parameters.Length == 2 &&
                   parameters[0].ParameterType == typeof(string) &&
                   parameters[1].ParameterType == typeof(string);
        });
    }

    internal static bool CallsLocalizationAddWordBestEffort(
        MethodInfo method)
    {
        return TryInspect(
                   method,
                   out MethodBase[] calls,
                   out _,
                   allowUnresolvedMethods: true) &&
               calls.Any(IsLocalizationAddWord);
    }

    internal static bool CallsDirectoryFileEnumeration(
        MethodInfo method)
    {
        return TryInspect(
                   method,
                   out MethodBase[] calls,
                   out _) &&
               calls.Any(called =>
                   called.DeclaringType == typeof(System.IO.Directory) &&
                   (string.Equals(
                        called.Name,
                        nameof(System.IO.Directory.GetFiles),
                        StringComparison.Ordinal) ||
                    string.Equals(
                        called.Name,
                        nameof(System.IO.Directory.EnumerateFiles),
                        StringComparison.Ordinal)));
    }

    internal static bool CallsDirectoryFileEnumerationBestEffort(
        MethodInfo method)
    {
        return TryInspect(
                   method,
                   out MethodBase[] calls,
                   out _,
                   allowUnresolvedMethods: true) &&
               calls.Any(IsDirectoryFileEnumeration);
    }

    internal static bool CallsDelegateInvoke(MethodInfo method)
    {
        return !TryInspect(
                   method,
                   out MethodBase[] calls,
                   out _) ||
               calls.Any(called =>
                   string.Equals(
                       called.Name,
                       "DynamicInvoke",
                       StringComparison.Ordinal) ||
                   string.Equals(
                       called.Name,
                       "Invoke",
                       StringComparison.Ordinal) &&
                   called.DeclaringType != null &&
                   typeof(Delegate).IsAssignableFrom(
                       called.DeclaringType));
    }

    internal static bool CallsDelegateInvokeBestEffort(
        MethodInfo method)
    {
        return !TryInspect(
                   method,
                   out MethodBase[] calls,
                   out _,
                   allowUnresolvedMethods: true) ||
               calls.Any(IsDelegateInvoke);
    }

    internal static bool HasFieldWrites(MethodInfo method)
    {
        return !TryInspect(
                   method,
                   out _,
                   out bool hasFieldWrites) ||
               hasFieldWrites;
    }

    internal static bool HasCanonicalLocalizeKeyBody(
        MethodInfo method)
    {
        if (!TryInspect(
                method,
                out MethodBase[] calls,
                out bool hasFieldWrites) ||
            hasFieldWrites)
        {
            return false;
        }

        foreach (MethodBase called in calls)
        {
            Type? declaringType = called.DeclaringType;
            if (declaringType == typeof(Localization) &&
                (string.Equals(
                     called.Name,
                     "AddWord",
                     StringComparison.Ordinal) ||
                 string.Equals(
                     called.Name,
                     "Localize",
                     StringComparison.Ordinal) ||
                 string.Equals(
                     called.Name,
                     "get_instance",
                     StringComparison.Ordinal)))
            {
                continue;
            }

            if (declaringType == typeof(IDisposable) &&
                string.Equals(
                    called.Name,
                    nameof(IDisposable.Dispose),
                    StringComparison.Ordinal))
            {
                continue;
            }

            if (string.Equals(
                    declaringType?.Namespace,
                    "System.Collections.Generic",
                    StringComparison.Ordinal) &&
                (string.Equals(
                     called.Name,
                     "TryGetValue",
                     StringComparison.Ordinal) ||
                 string.Equals(
                     called.Name,
                     "GetEnumerator",
                     StringComparison.Ordinal) ||
                 string.Equals(
                     called.Name,
                     "MoveNext",
                     StringComparison.Ordinal) ||
                 string.Equals(
                     called.Name,
                     "get_Current",
                     StringComparison.Ordinal) ||
                 string.Equals(
                     called.Name,
                     "Dispose",
                     StringComparison.Ordinal)))
            {
                continue;
            }

            return false;
        }

        return true;
    }

    private static bool TryInspect(
        MethodInfo method,
        out MethodBase[] calls,
        out bool hasFieldWrites,
        bool allowUnresolvedMethods = false)
    {
        calls = Array.Empty<MethodBase>();
        hasFieldWrites = false;
        MethodBody? body;
        byte[]? il;
        try
        {
            body = method.GetMethodBody();
            il = body?.GetILAsByteArray();
        }
        catch
        {
            return false;
        }

        if (il == null)
        {
            return false;
        }

        List<MethodBase> resolvedCalls = new();
        int position = 0;
        while (position < il.Length)
        {
            OpCode opcode;
            byte first = il[position++];
            if (first == 0xfe)
            {
                if (position >= il.Length)
                {
                    return false;
                }

                opcode = MultiByteOpCodes[il[position++]];
            }
            else
            {
                opcode = SingleByteOpCodes[first];
            }

            if (opcode.Size == 0)
            {
                return false;
            }

            if (opcode == OpCodes.Calli)
            {
                return false;
            }

            if (opcode.OperandType == OperandType.InlineMethod)
            {
                if (position + 4 > il.Length)
                {
                    return false;
                }

                int token = BitConverter.ToInt32(il, position);
                MethodBase? called = ResolveMethod(method, token);
                if (called == null)
                {
                    if (!allowUnresolvedMethods)
                    {
                        return false;
                    }
                }
                else
                {
                    resolvedCalls.Add(called);
                }
            }

            if (opcode == OpCodes.Stfld ||
                opcode == OpCodes.Stsfld)
            {
                hasFieldWrites = true;
            }

            int operandSize = GetOperandSize(
                opcode.OperandType,
                il,
                position);
            if (operandSize < 0 ||
                position + operandSize > il.Length)
            {
                return false;
            }

            position += operandSize;
        }

        calls = resolvedCalls.ToArray();
        return true;
    }

    private static bool IsLocalizationAddWord(
        MethodBase called)
    {
        if (called.DeclaringType != typeof(Localization) ||
            !string.Equals(
                called.Name,
                "AddWord",
                StringComparison.Ordinal))
        {
            return false;
        }

        ParameterInfo[] parameters = called.GetParameters();
        return parameters.Length == 2 &&
               parameters[0].ParameterType == typeof(string) &&
               parameters[1].ParameterType == typeof(string);
    }

    private static bool IsDirectoryFileEnumeration(
        MethodBase called)
    {
        return called.DeclaringType == typeof(System.IO.Directory) &&
               (string.Equals(
                    called.Name,
                    nameof(System.IO.Directory.GetFiles),
                    StringComparison.Ordinal) ||
                string.Equals(
                    called.Name,
                    nameof(System.IO.Directory.EnumerateFiles),
                    StringComparison.Ordinal));
    }

    private static bool IsDelegateInvoke(MethodBase called)
    {
        return string.Equals(
                   called.Name,
                   "DynamicInvoke",
                   StringComparison.Ordinal) ||
               string.Equals(
                   called.Name,
                   "Invoke",
                   StringComparison.Ordinal) &&
               called.DeclaringType != null &&
               typeof(Delegate).IsAssignableFrom(
                   called.DeclaringType);
    }

    private static MethodBase? ResolveMethod(
        MethodInfo caller,
        int token)
    {
        try
        {
            Type[]? typeArguments =
                caller.DeclaringType?.IsGenericType == true
                    ? caller.DeclaringType.GetGenericArguments()
                    : null;
            Type[]? methodArguments =
                caller.IsGenericMethod
                    ? caller.GetGenericArguments()
                    : null;
            return caller.Module.ResolveMethod(
                token,
                typeArguments,
                methodArguments);
        }
        catch
        {
            return null;
        }
    }

    private static int GetOperandSize(
        OperandType operandType,
        byte[] il,
        int position)
    {
        switch (operandType)
        {
            case OperandType.InlineNone:
                return 0;
            case OperandType.ShortInlineBrTarget:
            case OperandType.ShortInlineI:
            case OperandType.ShortInlineVar:
                return 1;
            case OperandType.InlineVar:
                return 2;
            case OperandType.InlineBrTarget:
            case OperandType.InlineField:
            case OperandType.InlineI:
            case OperandType.InlineMethod:
            case OperandType.InlineSig:
            case OperandType.InlineString:
            case OperandType.InlineTok:
            case OperandType.InlineType:
            case OperandType.ShortInlineR:
                return 4;
            case OperandType.InlineI8:
            case OperandType.InlineR:
                return 8;
            case OperandType.InlineSwitch:
                if (position + 4 > il.Length)
                {
                    return -1;
                }

                int count = BitConverter.ToInt32(il, position);
                return count < 0 ? -1 : 4 + count * 4;
            default:
                return -1;
        }
    }

    private static bool SameMethod(
        MethodBase left,
        MethodBase right)
    {
        try
        {
            return left.Module == right.Module &&
                   left.MetadataToken == right.MetadataToken;
        }
        catch
        {
            return left == right;
        }
    }
}
