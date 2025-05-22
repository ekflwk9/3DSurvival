using System;
using UnityEngine;

public enum ItemCode
{
    None = 0,
    MeleeItem = 1,
}

public class ItemManager
{
    public ItemData[] item { get; private set; }

    public void Load()
    {
        var items = Resources.LoadAll<ItemData>("ItemData");
        item = new ItemData[items.Length];

        for (int i = 0; i < items.Length; i++)
        {
            if (Enum.TryParse<ItemCode>(items[i].name, out var itemType))
            {
                var index = (int)itemType;
                item[index] = items[index];
            }
        }
    }
}
