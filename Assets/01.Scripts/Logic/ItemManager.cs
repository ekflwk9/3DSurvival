using System;
using UnityEngine;

public enum ItemCode
{
    None = 0,
    Potion = 1,
}

public class ItemManager
{
    public ItemData[] type { get; private set; }

    public void Load()
    {
        var items = Resources.LoadAll<ItemData>("ItemData");
        type = new ItemData[items.Length];

        for (int i = 0; i < items.Length; i++)
        {
            if (Enum.TryParse<ItemCode>(items[i].name, out var itemType))
            {
                var index = (int)itemType;
                type[index] = items[index];
            }
        }
    }
}
