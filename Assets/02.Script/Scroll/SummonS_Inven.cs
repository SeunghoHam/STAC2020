using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonS_Inven : MonoBehaviour
{
    public GameObject Character;
    public GameObject s_InvenScroll;
    public SelItemSlot SelItem;

    public void SummonS_InvenScroll()
    {
        if (SelItem.SelItem.item != Item.ItemList.None)
            SelItem.SetSelItemSlot(Item.ItemList.None, 0);
        else
        {
            GameObject AnotherS_InvenScroll = GameObject.FindGameObjectWithTag("S_INVEN");
            if (AnotherS_InvenScroll != null)
                AnotherS_InvenScroll.GetComponent<S_InvenScroll>().Destroy_S_Inven();
            Instantiate(s_InvenScroll, Character.transform).GetComponent<S_InvenScroll>().SelItem = SelItem;
        }
    }
}
