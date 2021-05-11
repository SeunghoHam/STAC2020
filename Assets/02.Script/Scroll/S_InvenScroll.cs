using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class S_InvenScroll : MonoBehaviour
{
    public GameObject Panel;
    public GameObject canvas;
    public GameObject Content;
    public GameObject SlotPrefab;
    public GameObject ExitButtonPrefab;
    public GameObject ExitButton;

    public Transform        ExitButtonAnchor;
    public ScrollRect       SR;
    public S_Inven_Exit     S_Exit;
    public List<InvenSlot>  S_InvenSlots;
    public Inventory        inventory;
    public SelItemSlot      SelItem;

    [Header("슬롯 갯수")]
    public int SlotCount;

    public void SelItemSet(Item.ItemList item, int Count)
    {
        SelItem.SetSelItemSlot(item, Count);
    }

    public void AddItemToSlot(Item.ItemList item, int ItemCount)
    {
        for (int i = 0; i < S_InvenSlots.Count; i++)
            if (S_InvenSlots[i].item.item == item)
            {
                S_InvenSlots[i].SetInvenSlot(item, S_InvenSlots[i].item.Count + ItemCount);
                return;
            }

        for (int i = 0; i < S_InvenSlots.Count; i++)
            if (S_InvenSlots[i].item.item == Item.ItemList.None)
            {
                S_InvenSlots[i].SetInvenSlot(item, ItemCount);
                return;
            }

        //인벤이 꽉찼을때 내려옴
    }

    public void InitS_InvenScroll ()
    {
        for (int i = 0; i < SlotCount; i++)
        {
            S_InvenSlots.Add(Instantiate(SlotPrefab, Panel.transform).GetComponent<InvenSlot>());
            S_InvenSlots[i].is_S_Inven = true;
            S_InvenSlots[i].SelItem_d += SelItemSet;
            S_InvenSlots[i].Destroy_s += Destroy_S_Inven;
        }

        if (transform.position.y > 413)
            Content.transform.position = new Vector2(Content.transform.position.x, 
                                                     Content.transform.position.y + (413 - transform.position.y));
        else if (transform.position.y < 225)
            Content.transform.position = new Vector2(Content.transform.position.x,
                                                     Content.transform.position.y + (225 - transform.position.y));

        ExitButton = Instantiate(ExitButtonPrefab, canvas.transform);
        ExitButton.transform.position = ExitButtonAnchor.position;
        S_Exit = ExitButton.GetComponent<S_Inven_Exit>();
        S_Exit.S_Inven = gameObject;

        SR = Content.GetComponentInParent<ScrollRect>();
        SR.vertical = false;

        inventory = GameObject.FindGameObjectWithTag("INVENTORY").GetComponent<Inventory>();

        for (int i = 0; i < inventory.items.Count; i++)
            S_InvenSlots[i].SetInvenSlot(inventory.items[i].item, inventory.items[i].Count);
    }

    public void Destroy_S_Inven()
    {
        SR.vertical = true;
        Destroy(ExitButton);
        Destroy(gameObject);
    }

    void Awake ()
    {
        Content = GameObject.FindGameObjectWithTag("CONTENT");
        canvas = GameObject.FindGameObjectWithTag("CANVAS");
        InitS_InvenScroll();
    }
}
