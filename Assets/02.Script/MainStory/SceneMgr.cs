using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneMgr : MonoBehaviour
{
    public float LimitTime;
    public Text text_Timer;
    public GameObject InventoryObject;
    public GameObject StoryObject;

    public void LoadScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    public void InitSceneMgr()
    {
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(InventoryObject);
        DontDestroyOnLoad(StoryObject);
    }

    private void Awake()
    {
        InitSceneMgr();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
            LoadScene("MainScene");

        if (LimitTime > 0)
        {
            LimitTime -= Time.deltaTime;
            text_Timer.text = " " + Mathf.Round(LimitTime) + " : 00 ";
            if (LimitTime < 0)
            {
                LoadScene("MainScene");
            }
        }

    }
}
