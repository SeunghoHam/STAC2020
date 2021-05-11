using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DropItem : MonoBehaviour
{
    public Item item = new Item(Item.ItemList.None, 1);
    public Inventory inventory;
    public Image image;

    public void ClickItem()
    {
        inventory.GiveItem(item.item, item.Count);
        Destroy(gameObject);
    }

    public void InitDropItem()
    {
        image = GetComponent<Image>();
        inventory = GameObject.FindGameObjectWithTag("INVENTORY").GetComponent<Inventory>();
        item.item = Item.ItemList.나무;
        image.sprite = Inventory.ItemSprites[(int)Item.ItemList.나무];
    }

    void Start()
    {
        InitDropItem();
    }
}
