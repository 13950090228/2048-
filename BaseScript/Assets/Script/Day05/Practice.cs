using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>

public class Practice : MonoBehaviour 
{
    public float speed = 10;
    private float x = 0;
    private GameObject someObject;
    private Camera mainCamera;

    public void Start()
    {
        mainCamera = Camera.main;
    }

    public void Update()
    {

      



        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        
        MoveRotation(hor, ver);
        //if (Input.GetKeyDown(KeyCode.W))
        //{

        //    Debug.Log("W");
        //    transform.rotation = Quaternion.Euler(0,0,0);

        //}

        //if (Input.GetKeyDown(KeyCode.A))
        //{

        //    Debug.Log("A");
        //    transform.rotation = Quaternion.Euler(0, -90, 0);

        //}

        //if (Input.GetKeyDown(KeyCode.D))
        //{

        //    Debug.Log("D");
        //    transform.rotation = Quaternion.Euler(0, 90, 0);
        //}

        //if (Input.GetKeyDown(KeyCode.S))
        //{

        //    Debug.Log("S");
        //    transform.rotation = Quaternion.Euler(0, 180, 0);
        //}
        //transform.position += transform.forward * Time.deltaTime * speed;
    }


    private void MoveRotation(float hor,float ver)
    {
        Vector3 screenPoint = mainCamera.WorldToScreenPoint(transform.position);
        if((screenPoint.x<=0 && hor<0) || (screenPoint.x >= Screen.width && hor>0))
        {
            hor = 0;
        }

        //if ((screenPoint.y <= 0 && ver < 0) || (screenPoint.y >= Screen.height && ver > 0))
        //{
        //    ver = 0;
        //}

        if (screenPoint.y>Screen.height)
        {
            screenPoint.y = 0;
            transform.position = mainCamera.ScreenToWorldPoint(screenPoint);

        }

        if (screenPoint.y < 0)
        {
            screenPoint.y = Screen.height;
            transform.position =  mainCamera.ScreenToWorldPoint(screenPoint);
        }
        



        if (hor!=0 || ver != 0)
        {
            Quaternion dir = Quaternion.LookRotation(new Vector3(hor, 0, ver));
            transform.rotation = dir;
            //transform.position += transform.forward * Time.deltaTime * speed;
            transform.Translate(0, 0, Time.deltaTime * speed, Space.Self);
        }

    }
}
