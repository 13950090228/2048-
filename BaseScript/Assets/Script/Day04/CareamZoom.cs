using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>

public class CareamZoom : MonoBehaviour 
{
    public bool isDown;
    public Camera mainCamera;
    public bool isFar= true ;
    public float[] levelArray;
    public int index = 0;
    public void Start()
    {
        mainCamera = transform.GetComponent<Camera>();
    }

    public void Update()
    {
        //Input.GetMouseButton(0);
        //if(Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.D))
        //{
        //    print("ctrl+D");
        //}


        if (Input.GetMouseButtonDown(1))
        {
            isFar = !isFar;
            if (isFar)
            {
                index = (index + 1) % levelArray.Length;

            }


        }

        if (isFar)
        {
            //if (mainCamera.fieldOfView < 60)
            //{
            //    mainCamera.fieldOfView += 1;
            //}
            //由快到慢，无限接近终点


            mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, levelArray[index], 0.1f);
            if (Mathf.Abs(mainCamera.fieldOfView - levelArray[index]) <= 0.1f)
            {
                mainCamera.fieldOfView = levelArray[index];
            }


        }
        //else
        //{
        //    //if (mainCamera.fieldOfView > 20)
        //    //{
        //    //    mainCamera.fieldOfView -= 1;
        //    //}
        //    mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, 20, 0.1f);
        //    if (Mathf.Abs(mainCamera.fieldOfView - 20) <= 0.1f)
        //    {
        //        mainCamera.fieldOfView = 20;
        //    }

        //}

    }


}
