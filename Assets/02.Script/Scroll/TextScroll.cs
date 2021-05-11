using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScroll : MonoBehaviour
{ 
    public GameObject Content;
    public GameObject Text;
    public RectTransform TextRt;
    public Text String;
    public StoryMgr story;
    public Image image;

    void Awake()    
    {
        story = GameObject.FindGameObjectWithTag("STORY").GetComponent<StoryMgr>();
        TextRt = Text.GetComponent<RectTransform>();
        String = Text.GetComponent<Text>();
        if (story.NextStory.Length > 10)
        {
            String.text = story.NextStory;
        }
        if(story.Scroll_Image != null)
        {
            image.sprite = story.Scroll_Image;
            story.Scroll_Image = null;
        }
        Content.GetComponent<RectTransform>().sizeDelta = new Vector2(0, String.preferredHeight * 0.1f + 200);
    }
}
