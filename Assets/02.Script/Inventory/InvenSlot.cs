using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvenSlot : MonoBehaviour
{
    public Item item = new Item(Item.ItemList.None, 0);
    public Text ItemCountText;
    public GameObject Panel;
    public Image ItemImage;

    public bool is_S_Inven = false;
    public delegate void SelectItem(Item.ItemList item, int Count);
    public delegate void DestroyS_Inven();
    public event SelectItem SelItem_d;
    public event DestroyS_Inven Destroy_s;

    public void SetInvenSlot(Item.ItemList item, int ItemCount)
    {
        this.item.ItemSet(item, ItemCount);
        ItemCountText.text = this.item.Count.ToString("f0");
        if (Item.ItemList.None != item)
            ItemImage.sprite = Inventory.ItemSprites[(int)this.item.item];
        if (this.item.Count <= 0)
            Panel.SetActive(false);
        else
            Panel.SetActive(true);
    }


    void Awake()
    {
        SetInvenSlot(Item.ItemList.None, 0);    
    }

    void Start()
    {
    }

    public void ClickSlot()
    {
        if (is_S_Inven)
        {
            SelItem_d(item.item, 1);
            Destroy_s();
        }
    }

}
