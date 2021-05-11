using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Inven_Exit : MonoBehaviour
{
    public GameObject S_Inven;
    UICtrl UI;

    void InitS_Inven_ExitButton()
    {
        UI = GameObject.FindGameObjectWithTag("UIOBJECT").GetComponent<UICtrl>();
        UI.Exit_S_Inven_Event += ExitButtonDown;
    }

    public void ExitButtonDown()
    {
        UI.Exit_S_Inven_Event -= ExitButtonDown;
        if (S_Inven != null)
            S_Inven.GetComponent<S_InvenScroll>().Destroy_S_Inven();
    }

    void Awake()
    {
        InitS_Inven_ExitButton();   
    }
}
