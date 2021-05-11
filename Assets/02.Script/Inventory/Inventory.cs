using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    public static Sprite[] ItemSprites;
    public Sprite[] TempSprites;
    public void GiveItem(Item.ItemList item, int ItemCount)
    {
        for (int i = 0; i < items.Count; i++)
            if (items[i].item == item)
            {
                items[i].ItemSet(item, items[i].Count + ItemCount);
                return;
            }

        items.Add(new Item(item, ItemCount));
    }

    public void InitInven()
    {
        ItemSprites = new Sprite[TempSprites.Length];
        for (int i = 0; i < TempSprites.Length; i++)
            ItemSprites[i] = TempSprites[i];
    }

    public void SaveInven()
    {

    }

    public void LoadInven()
    {

    }


    void Awake()
    {
        InitInven();
    }

    void Start()
    {
    }
}
