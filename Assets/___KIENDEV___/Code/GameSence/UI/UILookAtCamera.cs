using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILookAtCamera : MonoBehaviour
{

  

    [Header("Cài Đặt")]
    public LookAtMode lookAtMode = LookAtMode.YAxisOnly;

    void LateUpdate()
    {
        if ( lookAtMode == LookAtMode.FullRotation){
            Rotate_Full();
        }
        if (lookAtMode == LookAtMode.YAxisOnly){
            Rotate_Y();
        }
    }

    void Rotate_Full(){
         transform.LookAt(transform.position+Camera.main.transform.forward);
    }

    void Rotate_Y(){
        Vector3 targetPosition = transform.position + Camera.main.transform.forward;
        targetPosition.y = transform.position.y;
        transform.LookAt(targetPosition);
    }
}


public enum LookAtMode
{
    FullRotation,   // Xoay cả 3 trục
    YAxisOnly       // Chỉ xoay theo trục Y
}