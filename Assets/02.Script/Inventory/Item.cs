using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum ItemList
    {
        None,
        나무,      
        돌,    
        나뭇잎,     
        가죽,  
        천,      
        비닐,   
        알수없는식물,  
        고무,    
        우비,
        우산,
        옷,
        칼,
        새총,
        창,
        활과화살,
        뗏목,
        EndItemList,
    }

    public ItemList item;
    public int Count;

    public Item(ItemList item, int ItemCount)
    {
        this.item = item;
        this.Count = ItemCount;
    }

    public void ItemSet(ItemList item, int ItemCount)
    {
        this.item = item;
        this.Count = ItemCount;
    }
}