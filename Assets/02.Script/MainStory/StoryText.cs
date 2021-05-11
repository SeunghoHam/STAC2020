using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryText : MonoBehaviour
{
    [Header("아이템 획득 스토리")]
    public string[] GetItemText;

    [Header("사건 사고 스토리")]
    public string[] AccidentText;

    [Header("사건 사고 결과 스토리")]
    public string[] Accident_Result_Text;//1 소나기 결과/ 2 나머지 결과
    public Sprite[] Accident_Image;

    [Header("행동 스토리")]
    public string[] Plant_Text;   //1 식물 스토리/ 2 식용/ 3 약용/ 4 독/ 5 식물감정 안함
    public string[] Animal_Text;  //1 곰      /2 멧돼지   /3 사슴/ 4 고라니/ 5 꿩/ 6 토끼/ 7 도망/ 8 사냥 실패
    public string[] Create_Text;  //1 제작?   /2 제작성공 /3 제작 실패
    public string[] Heal_Text;    //1 치료?   /2 치료성공 /3 치료 안함
    public string[] Water_Text;   //1 물?     /2 1개     /3 2개  /4 3개 /5 안뜸
    public string[] Rest_Text;    //휴식

    public string ClipStoryText(Item.ItemList item)
    {
        string[] TextArr;
        string ClipText = "";
        if (Item.ItemList.나무 <= item && item <= Item.ItemList.나뭇잎)
            TextArr = GetItemText[Random.Range(0, 2)].Split('A');
        else if (Item.ItemList.가죽 <= item && item <= Item.ItemList.비닐)
            TextArr = GetItemText[Random.Range(0, 2) + 2].Split('A');
        else if (Item.ItemList.알수없는식물 == item)
            TextArr = GetItemText[Random.Range(0, 2) + 4].Split('A');
        else if (Item.ItemList.고무 == item)
            TextArr = GetItemText[6].Split('A');
        else
            return "";
        if (TextArr.Length <= 1)
            return TextArr[0];
        else
        {
            ClipText = TextArr[0];
            for (int i = 1; i < TextArr.Length; i++)
                ClipText += "<color=#ff0000>" + item + "</color>" + TextArr[i];
        }
        return ClipText;
    }
}
