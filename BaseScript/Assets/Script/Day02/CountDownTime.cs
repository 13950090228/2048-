using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 
/// </summary>

public class CountDownTime : MonoBehaviour 
{
    private Text txtTime;
    public int second = 300;
    private float totalTime =0;


    public void Start()
    {
        txtTime = GetComponent<Text>();
    }
    public void Update()
    {
        //totalTime += Time.deltaTime;

        Timer1();


    }

    private void Timer1()
    {
        if (Time.time >= totalTime)
        {
            second--;
            if (second >= 0)
            {
                txtTime.text = string.Format("{0:d2}:{1:d2}", second / 60, second % 60);
            }

            if (second < 60)
            {
                txtTime.color = Color.red;
            }

            totalTime = Time.time + 1;
        }
    }
}
