using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using BepInEx.Configuration;
using Jotunn;
using Jotunn.Managers;
using UnityEngine;

/// <summary>
///     Class that specifies how a setting should be displayed inside the ConfigurationManager settings window.
///
///     Usage:
///     This class template has to be copied inside the plugin's project and referenced by its code directly.
///     make a new instance, assign any fields that you want to override, and pass it as a tag for your setting.
///
///     If a field is null (default), it will be ignored and won't change how the setting is displayed.
///     If a field is non-null (you assigned a value to it), it will override default behavior.
/// </summary>
///
/// <example> 
///     Here's an example of overriding order of settings and marking one of the settings as advanced:
///     <code>
///         // Override IsAdvanced and Order
///         Config.Bind("X", "1", 1, new ConfigDescription("", null, new ConfigurationManagerAttributes { IsAdvanced = true, Order = 3 }));
///         // Override only Order, IsAdvanced stays as the default value assigned by ConfigManager
///         Config.Bind("X", "2", 2, new ConfigDescription("", null, new ConfigurationManagerAttributes { Order = 1 }));
///         Config.Bind("X", "3", 3, new ConfigDescription("", null, new ConfigurationManagerAttributes { Order = 2 }));
///     </code>
/// </example>
///
/// <remarks> 
///     You can read more and see examples in the readme at https://github.com/BepInEx/BepInEx.ConfigurationManager
///     You can optionally remove fields that you won't use from this class, it's the same as leaving them null.
/// </remarks>
public sealed class ConfigurationManagerAttributes
{
	/// <summary>
	///     Should the setting be shown as a percentage (only use with value range settings).
	/// </summary>
	public bool? ShowRangeAsPercent;

	/// <summary>
	///     Custom setting editor (OnGUI code that replaces the default editor provided by ConfigurationManager).
	///     See below for a deeper explanation. Using a custom drawer will cause many of the other fields to do nothing.
	/// </summary>
	public Action<ConfigEntryBase> CustomDrawer;

	/// <summary>
	///     Show this setting in the settings screen at all? If false, don't show.
	/// </summary>
	public bool? Browsable;

	/// <summary>
	///     Category the setting is under. Null to be directly under the plugin.
	/// </summary>
	public string Category;

	/// <summary>
	///     If set, a "Default" button will be shown next to the setting to allow resetting to default.
	/// </summary>
	public object DefaultValue;

	/// <summary>
	///     Force the "Reset" button to not be displayed, even if a valid DefaultValue is available. 
	/// </summary>
	public bool? HideDefaultButton;

	/// <summary>
	///     Force the setting name to not be displayed. Should only be used with a <see cref="F:ConfigurationManagerAttributes.CustomDrawer" /> to get more space.
	///     Can be used together with <see cref="F:ConfigurationManagerAttributes.HideDefaultButton" /> to gain even more space.
	/// </summary>
	public bool? HideSettingName;

	/// <summary>
	///     Optional description shown when hovering over the setting.
	///     Not recommended, provide the description when creating the setting instead.
	/// </summary>
	public string Description;

	/// <summary>
	///     Name of the setting.
	/// </summary>
	public string DispName;

	/// <summary>
	///     Order of the setting on the settings list relative to other settings in a category.
	///     0 by default, higher number is higher on the list.
	/// </summary>
	public int? Order;

	/// <summary>
	///     Only show the value, don't allow editing it.
	/// </summary>
	public bool? ReadOnly;

	/// <summary>
	///     If true, don't show the setting by default. User has to turn on showing advanced settings or search for it.
	/// </summary>
	public bool? IsAdvanced;

	/// <summary>
	///     Custom converter from setting type to string for the built-in editor textboxes.
	/// </summary>
	public Func<object, string> ObjToStr;

	/// <summary>
	///     Custom converter from string to setting type for the built-in editor textboxes.
	/// </summary>
	public Func<string, object> StrToObj;

	private bool isAdminOnly;

	private bool isUnlocked = true;

	private static readonly PropertyInfo[] _myProperties = typeof(ConfigurationManagerAttributes).GetProperties(BindingFlags.Instance | BindingFlags.Public);

	private static readonly FieldInfo[] _myFields = typeof(ConfigurationManagerAttributes).GetFields(BindingFlags.Instance | BindingFlags.Public);

	/// <summary>
	///     Whether a config is only writable by admins and gets overwritten on connecting clients
	/// </summary>
	public bool IsAdminOnly
	{
		get
		{
			return isAdminOnly;
		}
		set
		{
			isAdminOnly = value;
			bool flag = isAdminOnly && !SynchronizationManager.Instance.PlayerIsAdmin;
			IsUnlocked = !flag;
		}
	}

	/// <summary>
	///     Color of the entry text
	/// </summary>
	public Color EntryColor { get; set; }

	/// <summary>
	///     Color of the description text
	/// </summary>
	public Color DescriptionColor { get; set; }

	/// <summary>
	///     Whether a config is locked for direct writing
	/// </summary>
	public bool IsUnlocked
	{
		get
		{
			return isUnlocked;
		}
		internal set
		{
			ReadOnly = !value;
			HideDefaultButton = !value;
			isUnlocked = value;
		}
	}

	/// <summary>
	///     ctor
	/// </summary>
	public ConfigurationManagerAttributes()
	{
		EntryColor = new Color(1f, 0.631f, 0.235f, 1f);
		DescriptionColor = Color.white;
	}

	/// <summary>
	///     Set config values from an attribute array
	/// </summary>
	/// <param name="attribs">Array of attribute values</param>
	public void SetFromAttributes(object[] attribs)
	{
		if (attribs == null || attribs.Length == 0)
		{
			return;
		}
		foreach (object obj in attribs)
		{
			if (obj == null)
			{
				continue;
			}
			if (!(obj is DisplayNameAttribute displayNameAttribute))
			{
				if (!(obj is CategoryAttribute categoryAttribute))
				{
					if (!(obj is DescriptionAttribute descriptionAttribute))
					{
						if (!(obj is DefaultValueAttribute defaultValueAttribute))
						{
							if (!(obj is ReadOnlyAttribute readOnlyAttribute))
							{
								if (!(obj is BrowsableAttribute browsableAttribute))
								{
									if (obj is string text)
									{
										switch (text)
										{
										case "ReadOnly":
											ReadOnly = true;
											break;
										case "Browsable":
											Browsable = true;
											break;
										case "Unbrowsable":
										case "Hidden":
											Browsable = false;
											break;
										case "Advanced":
											IsAdvanced = true;
											break;
										}
										continue;
									}
									Type type = obj.GetType();
									if (!(type.Name == "ConfigurationManagerAttributes"))
									{
										break;
									}
									FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public);
									foreach (var item in from my in _myProperties
										join other in fields on my.Name equals other.Name
										select new { my, other })
									{
										try
										{
											object obj2 = item.other.GetValue(obj);
											if (obj2 != null)
											{
												if (item.my.PropertyType != item.other.FieldType && typeof(Delegate).IsAssignableFrom(item.my.PropertyType))
												{
													obj2 = Delegate.CreateDelegate(item.my.PropertyType, ((Delegate)obj2).Target, ((Delegate)obj2).Method);
												}
												item.my.SetValue(this, obj2, null);
											}
										}
										catch (Exception ex)
										{
											Jotunn.Logger.LogWarning("Failed to copy value " + item.my.Name + " from provided tag object " + type.FullName + " - " + ex.Message);
										}
									}
									foreach (var item2 in from my in _myFields
										join other in fields on my.Name equals other.Name
										select new { my, other })
									{
										try
										{
											object obj3 = item2.other.GetValue(obj);
											if (obj3 != null)
											{
												if (item2.my.FieldType != item2.other.FieldType && typeof(Delegate).IsAssignableFrom(item2.my.FieldType))
												{
													obj3 = Delegate.CreateDelegate(item2.my.FieldType, ((Delegate)obj3).Target, ((Delegate)obj3).Method);
												}
												item2.my.SetValue(this, obj3);
											}
										}
										catch (Exception ex2)
										{
											Jotunn.Logger.LogWarning("Failed to copy value " + item2.my.Name + " from provided tag object " + type.FullName + " - " + ex2.Message);
										}
									}
								}
								else
								{
									Browsable = browsableAttribute.Browsable;
								}
							}
							else
							{
								ReadOnly = readOnlyAttribute.IsReadOnly;
							}
						}
						else
						{
							DefaultValue = defaultValueAttribute.Value;
						}
					}
					else
					{
						Description = descriptionAttribute.Description;
					}
				}
				else
				{
					Category = categoryAttribute.Category;
				}
			}
			else
			{
				DispName = displayNameAttribute.DisplayName;
			}
		}
	}
}
