using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;

public class ShipCamMgr : MonoBehaviour
{
    public float rotSpeed = 200.0f;
    void Update()
    {
        float h = Input.GetAxis("Mouse X");
        float v = Input.GetAxis("Mouse Y");

        UnityEngine.Vector3 dir = new UnityEngine.Vector3(-v, h, 0);
        UnityEngine.Vector3 angle = transform.eulerAngles;
        angle += dir * 5 * Time.deltaTime;
        transform.eulerAngles = angle;
    }
    /*
    [SerializeField] Transform tf_crosshair;
    [SerializeField] Transform tf_cam;
    [SerializeField] float sightSensivitty;
    [SerializeField] float LookLimitX;
    [SerializeField] float LookLimitY;
    float currentAngleY;
    float currentAngleX ;
        void Update()
    {
        CrosshairMoving();
        ViewMoving();
    }
    void ViewMoving()
    {
        if (tf_crosshair.localPosition.x > (Screen.width /2 - 100)
            || tf_crosshair.localPosition.x < (Screen.width/2 + 100))
            {
            Debug.Log("화면이 이동중");
            currentAngleY += (tf_crosshair.localPosition.x > 0) ? sightSensivitty : -sightSensivitty;
            currentAngleY = Mathf.Clamp(currentAngleY, -LookLimitX, LookLimitX);
            tf_cam.localEulerAngles = new UnityEngine.Vector3(currentAngleX, currentAngleY, tf_cam.localEulerAngles.z);
            }


    }
 


    void CrosshairMoving()
    {
        Debug.Log("크로스 헤어 실행중");
        tf_crosshair.localPosition = new UnityEngine.Vector2(Input.mousePosition.x
           -(Screen.width/2), Input.mousePosition.y - (Screen.height/2));
        //tf_crosshair.localPosition = Input.mousePosition;
       
        float t_cursorPosX = tf_crosshair.localPosition.x;
        float t_cursorPosY = tf_crosshair.localPosition.y;

        t_cursorPosX = Mathf.Clamp(t_cursorPosX, (-Screen.width / 2 -50),(Screen.width/2 -50));
        t_cursorPosX = Mathf.Clamp(t_cursorPosY, (-Screen.height / 2 -50),(Screen.height/2 -50));

        tf_crosshair.localPosition = new UnityEngine.Vector2(t_cursorPosX, t_cursorPosY);
    }*/
}
