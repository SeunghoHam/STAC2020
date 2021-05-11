using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvenScroll : MonoBehaviour
{
    public GameObject Panel;
    public GameObject SlotPrefab;
    public List<InvenSlot> InvenSlots;
    public Inventory inventory;

    [Header("슬롯 갯수")]
    public int SlotCount;

    void AddItemToSlot(Item.ItemList item, int ItemCount)
    {
        for (int i = 0; i < InvenSlots.Count; i++)
            if (InvenSlots[i].item.item == item)
            {
                InvenSlots[i].SetInvenSlot(item, InvenSlots[i].item.Count + ItemCount);
                return;
            }

        for (int i = 0; i < InvenSlots.Count; i++)
            if (InvenSlots[i].item.item == Item.ItemList.None)
            {
                InvenSlots[i].SetInvenSlot(item, ItemCount);
                return;
            }

        //인벤이 꽉찼을때 내려옴
    }

    void InitInvenSlot()
    {
        for (int i = 0; i < SlotCount; i++)
            InvenSlots.Add(Instantiate(SlotPrefab, Panel.transform).GetComponent<InvenSlot>());
    }

    void InitInvenScroll()
    {
        for (int i = 0; i < inventory.items.Count; i++)
            InvenSlots[i].SetInvenSlot(inventory.items[i].item, inventory.items[i].Count);
    }

    void Awake()
    {
        inventory = GameObject.FindGameObjectWithTag("INVENTORY").GetComponent<Inventory>();
        InitInvenSlot();
    }

    void Start()
    {
        InitInvenScroll();
    }
}
