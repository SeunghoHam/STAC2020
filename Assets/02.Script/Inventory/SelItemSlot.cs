using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class SelItemSlot : MonoBehaviour
{
    public GameObject ImageObject;
    public Image image;
    public Item SelItem = new Item(Item.ItemList.None, 0);
    void Awake()
    {
        image = ImageObject.GetComponent<Image>();
        ImageObject.SetActive(false);
    }

    public void SetSelItemSlot(Item.ItemList item, int Count)
    {
        ImageObject.SetActive(true);
        SelItem.item = item;
        SelItem.Count = Count;
        image.sprite = Inventory.ItemSprites[(int)item];
        if (item == Item.ItemList.None)
            ImageObject.SetActive(false);
    }
}
