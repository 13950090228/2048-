using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>

public class TransformDemo : MonoBehaviour 
{
    private void OnGUI()
    {
        if (GUILayout.Button("循环变换组件"))

        {
            foreach(Transform child in this.transform)
            {
                Debug.Log(child.name);
            }
        }

        if (GUILayout.Button("移动"))

        {
            //向自身坐标系移动
            //this.transform.Translate(0, 0, 5, Space.Self);
            //向世界坐标系移动
            this.transform.Translate(0, 0, 5 * Time.deltaTime, Space.World);
        }

        if (GUILayout.Button("旋转"))

        {
            //向自身坐标系旋转
            this.transform.Rotate(0, 0, 10, Space.Self);
            //向世界坐标系旋转
            //this.transform.Rotate(0, 0, 5, Space.World);
        }

        //点住不放就一直做下去
        if (GUILayout.RepeatButton("围绕旋转"))

        {
            //围绕自身坐标系旋转
            this.transform.RotateAround(Vector3.zero,Vector3.up,1);
            //围绕世界坐标系旋转
            //this.transform.Rotate(0, 0, 5, Space.World);
        }

        if (GUILayout.Button("查找子物体"))
        {
            //根据名称
            //Transform childTF = transform.Find("Cube (1)");
            Transform childTF = transform.GetChild(2).GetChild(0);
            Debug.Log(childTF+"子物体");

        }

        if (GUILayout.Button("查找多个子物体"))
        {
            //根据索引查找子物体
            int count = this.transform.childCount;
            for (int i = 0; i < count; i++)
            {
                Transform childTF = transform.GetChild(i);
                
                Debug.Log(childTF);
            }

        }

        if (GUILayout.Button("创建灯光"))
        {
            //创建物体
            GameObject lightGo = new GameObject();
            //添加组件
            Light light = lightGo.AddComponent<Light>();
            light.color = Color.red;
            light.type = LightType.Point;

        }

        
    }

}
