using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;
using UnityEngine.UI;

public class StoryMgr : MonoBehaviour
{
    enum Accident
    {
        None,
        소나기,
        폭풍,
        지진,
        홍수,
        산불,
        AccidentEndCount,
    }

    enum Animal
    {
        None,
        곰,
        멧돼지,
        사슴,
        고라니,
        꿩,
        토끼,
        AnimalEndCount,
    }

    public int DayCount = 1;
    private int isDay5 = 1;

    public UICtrl UI;

    public SceneMgr sceneMgr;
    public Inventory inventory;
    public StoryText storyText;

    public string NextStory = "";
    public string AccidentStory = "";
    public string Behaviour_Plant_Story = "";
    public string Plant_Story_Temp = "";
    public string Result_Story = "";
    public string Accident_Result_Story = "";
    public Sprite Temp_Image = null;
    public Sprite Scroll_Image = null;

    void InitStoryMgr()
    {
        inventory = GameObject.FindGameObjectWithTag("INVENTORY").GetComponent<Inventory>();
    }

    void Awake()
    {
        InitStoryMgr();
    }

    public Item GiveRandomItem()
    {
        Behaviour_Plant_Story = Plant_Story_Temp;
        Plant_Story_Temp = "";
        int ItemNum = Random.Range(1, 101);
        if (ItemNum <= 20)
        {
            inventory.GiveItem(Item.ItemList.나무, 1);
            return new Item(Item.ItemList.나무, 1);
        }
        else if (ItemNum <= 40)
        {
            inventory.GiveItem(Item.ItemList.돌, 1);
            return new Item(Item.ItemList.돌, 1);
        }
        else if (ItemNum <= 60)
        {
            inventory.GiveItem(Item.ItemList.나뭇잎, 1);
            return new Item(Item.ItemList.나뭇잎, 1);
        }
        else if (ItemNum <= 69)
        {
            inventory.GiveItem(Item.ItemList.가죽, 1);
            return new Item(Item.ItemList.가죽, 1);
        }
        else if (ItemNum <= 78)
        {
            inventory.GiveItem(Item.ItemList.천, 1);
            return new Item(Item.ItemList.천, 1);
        }
        else if (ItemNum <= 87)
        {
            inventory.GiveItem(Item.ItemList.비닐, 1);
            return new Item(Item.ItemList.비닐, 1);
        }
        else if (ItemNum <= 96)
        {
            inventory.GiveItem(Item.ItemList.알수없는식물, 1);
            Plant_Story_Temp = storyText.Plant_Text[0];
            return new Item(Item.ItemList.알수없는식물, 1);
        }
        else if (ItemNum <= 100)
        {
            inventory.GiveItem(Item.ItemList.고무, 1);
            return new Item(Item.ItemList.고무, 1);
        }
        else
            return new Item(Item.ItemList.None, 0);
    }

    public void NextDay()
    {
        if (DayCount >= 5)
            isDay5 = 0;
        DayCount++;
        UI.ChangeDate(DayCount);
        NextStory = storyText.ClipStoryText(GiveRandomItem().item);
        RandomAccident();
        sceneMgr.LoadScene("MainScene");
    }

    public void LoadingStoryText()
    {
        if(Accident_Result_Story.Length > 3)
        {
            Result_Story = Accident_Result_Story;
            Accident_Result_Story = "";
        }
    }

    public void RandomAccident()
    {
        LoadingStoryText();
        int Eventnum = Random.Range(1, 101);
        if (Eventnum <= 100) //자연재해 10
        {
            Accident accident = (Accident)Random.Range((int)Accident.소나기, (int)Accident.AccidentEndCount);
            accident = (Accident)1;
            AccidentStory = storyText.AccidentText[(int)accident - 1];
            switch (accident)
            {
                case Accident.소나기: Accident_Result_Story = storyText.Accident_Result_Text[0];break;
                
                default: Accident_Result_Story = storyText.Accident_Result_Text[1]; break;
            }
            if ((int)accident - 1 < storyText.Accident_Image.Length)
            {
                Temp_Image = storyText.Accident_Image[(int)accident - 1];
            }
        }
        else if (Eventnum <= 25 + (isDay5 * 45)) //물 긷기 15
        {
            AccidentStory = storyText.Water_Text[0];
        }
        else if (Eventnum <= 40 + (isDay5 * 60)) // 야생동물 15
        {
            Animal animal = (Animal)Random.Range((int)Animal.곰, (int)Animal.AnimalEndCount);
            AccidentStory = storyText.Animal_Text[(int)animal - 1];
        }
        else if (Eventnum <= 60) // 아이템 제작 20
        {
            AccidentStory = storyText.Create_Text[0];
        }
        else if (Eventnum <= 80) // 치료 20
        {
            AccidentStory = storyText.Heal_Text[0];
        }
        else if (Eventnum <= 100) //휴식 20
        {
            AccidentStory = storyText.Rest_Text[0];
        }
        else
            return;
    }

}

