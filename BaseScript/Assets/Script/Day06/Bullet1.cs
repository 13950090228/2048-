using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>

public class Bullet1 : MonoBehaviour 
{
    public float speed = 10;
    private void OnCollisionEnter(Collision collision)
    {
        print("OnCollisionEnter" + collision.collider.name);

    }

    private void OnTriggerEnter(Collider other)
    {
        print("OnTriggerEnter--" + other);
    }

    //private void FixedUpdate()
    //{
    //    Debug.Log(Time.frameCount + "--" + transform.position);
    //    transform.Translate(0, 0, Time.deltaTime * speed,Space.Self);
    //}

    public LayerMask mask;
    private Vector3 targetPos;
    private void Start()
    {
        RaycastHit hit;
        //(起点坐标，方向，受击物体信息，距离)
        if (Physics.Raycast(transform.position, transform.forward, out hit, 100, mask))
        {//检测到物体
            targetPos = hit.point;

        }
        else
        {//没检测到物体
            targetPos = transform.position + transform.forward * 100;
        }
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed*Time.deltaTime);
        if ((transform.position - targetPos).sqrMagnitude < 0.1f)
        {
            print("检测到物体");
            print(targetPos);
        }

    }
}
