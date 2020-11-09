using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>

public class FindEnemyDemo : MonoBehaviour 
{



    private void OnGUI()
    {
        if (GUILayout.Button("查找血量最少"))
        {

            //查找场景中所有Enemy类型的引用
            Enemy[] aryEnemy = FindObjectsOfType<Enemy>();
            //获取血量最低的引用
            Enemy min = FindEnemyMinH(aryEnemy);
            //通过Enemy类型引用获取其他类型的引用
            min.GetComponent<MeshRenderer>().material.color = Color.red;

            Debug.Log(min);

        }

        if (GUILayout.Button("查找最近的物体"))
        {
            Transform[] aryObject = FindObjectsOfType<Transform>();
            float distanceMin = Vector3.Distance(transform.position, aryObject[0].position); ;
            for (int i = 1; i < aryObject.Length; i++)
            {
                if (aryObject[i] != transform)
                {
                    float distance = Vector3.Distance(transform.position, aryObject[i].position);

                    Debug.Log("该物体"+aryObject[i]+"与当前物体距离为"+distance);

                    if (distanceMin > distance)
                    {
                        distanceMin = distance;
                    }
                }
              
            }

            Debug.Log("距离最短为：" + distanceMin);

        }

        if (GUILayout.Button("不知层级查找子物体"))
        {
            var childTF = GetChildObject(transform, "Cube (7)");

            if (childTF != null)
            {
                childTF.GetComponent<MeshRenderer>().material.color = Color.red;
            }
            else
            {
                Debug.Log("查找不到此物体");
            }

        }
    }
    public Enemy FindEnemyMinH(Enemy[] aryEnemy)
    {
        Enemy min = aryEnemy[0];
        for (int i = 1; i < aryEnemy.Length; i++)
        {
            if (aryEnemy[i].HP < min.HP)
            {
                min = aryEnemy[i];
            }
        }

        return min;
    }

    public Transform GetChildObject(Transform parentTF, string childName)
    {
        //在子物体中查找
        Transform childTF = parentTF.Find(childName);
        if (childTF != null)
        {
            return childTF;
        }

        //在子物体下面
        int count = parentTF.childCount;
        for (int i = 0; i < count; i++)
        {
            childTF = GetChildObject(parentTF.GetChild(i), childName);
            if (childTF != null)
            {
                return childTF;
            }
        }

        return null;
    }

}
