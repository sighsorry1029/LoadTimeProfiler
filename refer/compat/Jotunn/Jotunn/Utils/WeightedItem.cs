namespace Jotunn.Utils;

/// <summary>
///     Weighted item used in <see cref="T:Jotunn.Utils.WeightedList`2" />
/// </summary>
/// <typeparam name="T"></typeparam>
public class WeightedItem<T>
{
	public T Item { get; private set; }

	public virtual float Weight { get; set; }

	public WeightedItem(T item, float weight = 0f)
	{
		Item = item;
		if (weight != 0f)
		{
			Weight = weight;
		}
	}
}
