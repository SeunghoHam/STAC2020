using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICtrl : MonoBehaviour
{
    public GameObject TextScrollPrefab;

    public GameObject DayCountObject;
    public GameObject DayCountShadowObject;
    public Text DayCount;
    public Text DayCountShadow;

    public GameObject CharScroll;
    public GameObject InvenScroll;
    public GameObject TextScroll;
    public List<GameObject> Scrolls = new List<GameObject>();
    public GameObject canvas;

    public int EnableScrollIdx = 0;

    public StoryMgr storyMgr;
    public delegate void Exit_S_Inven();
    public event Exit_S_Inven Exit_S_Inven_Event;

    void TempFuntion()
    {
    }

    void CreateNewTextScroll(int CreateIndex, ref string StoryText)
    {
        storyMgr.NextStory = StoryText;
        Scrolls.Insert(CreateIndex , Instantiate(TextScrollPrefab, canvas.transform));
        StoryText = "";
    }

    public void InitScrolls()
    {
        if (storyMgr.AccidentStory.Length > 3)
        {
            if (storyMgr.Temp_Image != null)
            {
                storyMgr.Scroll_Image = storyMgr.Temp_Image;
                storyMgr.Temp_Image = null;
            }
            CreateNewTextScroll(1, ref storyMgr.AccidentStory);
        }
        if (storyMgr.Behaviour_Plant_Story.Length > 3)
        {
            CreateNewTextScroll(0, ref storyMgr.Behaviour_Plant_Story);
        }
        if (storyMgr.Result_Story.Length > 3)
        {
            CreateNewTextScroll(0, ref storyMgr.Result_Story);
        }
    }

    void InitUICtrl()
    {
        DayCount = DayCountObject.GetComponent<Text>();
        DayCountShadow = DayCountShadowObject.GetComponent<Text>();
        storyMgr = GameObject.FindGameObjectWithTag("STORY").GetComponent<StoryMgr>();
        canvas = GameObject.FindGameObjectWithTag("CANVAS");
        storyMgr.UI = gameObject.GetComponent<UICtrl>();
        Exit_S_Inven_Event += TempFuntion;

    }

    void ChackScrolls()
    {
        for (int i = 0; i < Scrolls.Count; i++)
            Scrolls[i].SetActive(false);
        Scrolls[EnableScrollIdx].SetActive(true);
    }

    public void ChangeDate(int Day)
    {
        DayCount.text = "DAY " + Day;
        DayCountShadow.text = "DAY " + Day;
    }

    void Awake()
    {
        InitUICtrl();
    }

    void Start()
    {     
        InitScrolls();
        ChackScrolls();
        ChangeDate(storyMgr.DayCount);
    }

    public void ClickNextButton()
    {
        Exit_S_Inven_Event();

        if (EnableScrollIdx == Scrolls.Count - 1)
        {
            storyMgr.NextDay();
            EnableScrollIdx = 0;
            return;
        }
        EnableScrollIdx = EnableScrollIdx < Scrolls.Count ? ++EnableScrollIdx : EnableScrollIdx;
        ChackScrolls();
    }

    public void ClickBackButton()
    {
        Exit_S_Inven_Event();
        EnableScrollIdx = EnableScrollIdx > 0 ? --EnableScrollIdx : EnableScrollIdx;
        ChackScrolls();
    }

    public void ClickStopButton()
    {
        Exit_S_Inven_Event();
    }

    public void ClickMenuButton()
    {
        Exit_S_Inven_Event();
    }
}
