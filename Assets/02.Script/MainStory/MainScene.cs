using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainScene : MonoBehaviour
{
    private void Awake() 
    {
        Screen.SetResolution(450, 800,false);
    }
    public void Click()
    {
        SceneManager.LoadScene("ShipScene");
    }
}
