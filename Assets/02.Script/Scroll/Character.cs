using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public enum State
    {
        normal,
    }

    public SelItemSlot Slot;

    public string Name;
    public string Job;
    public int Life;
    public int Stamina;
    public State state;

    void Start()
    {
        //Slot.SetSelItemSlot(Item.ItemList.나무);    
    }
}
