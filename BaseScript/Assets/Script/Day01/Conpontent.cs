using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>

public class Conpontent : MonoBehaviour 
{
    public void OnGUI()
    {
        if (GUILayout.Button("改变位置"))
        {

            this.GetComponent<MeshRenderer>().material.color = Color.black;

        }

        if (GUILayout.Button("改变颜色"))
        {

            this.GetComponent<MeshRenderer>().material.color = Color.black;

        }

        if (GUILayout.Button("查看所有组件"))
        {
            var allCompontent = this.GetComponents<Component>();

            foreach (var item in allCompontent)
            {
                Debug.Log(item.GetType());
            }
        }

        //获取后代指定类型组件（从自身开始找）
        if (GUILayout.Button("查找子对象"))
        {
            var allCompontent = this.GetComponentsInChildren<MeshRenderer>();

            foreach (var item in allCompontent)
            {
                item.material.color = Color.red;
            }
        }
    }
}
