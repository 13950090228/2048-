using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>

public class itweenDemo : MonoBehaviour 
{
    public Transform img, end;

    public void Move()
    {
        iTween.MoveTo(img.gameObject, end.position, 2);
    }
}
