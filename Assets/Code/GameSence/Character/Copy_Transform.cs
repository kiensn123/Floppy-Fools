using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class Copy_Transform : MonoBehaviour
{
    public Transform  Parent_Tranform;
    public ConfigurableJoint cj;
    public Quaternion initialRotationOffset;

    public  bool mirrol;

    void Awake()
    {
        // if (Parent_Tranform != null)
        // {
        //     // initialRotationOffset = new Quaternion(0,0,0,0);
        //     // initialRotationOffset = Quaternion.Inverse(Parent_Tranform.rotation) * transform.rotation;
        //     initialRotationOffset = Quaternion.Inverse(Parent_Tranform.rotation) * transform.rotation;
        // }
        cj.rotationDriveMode = RotationDriveMode.Slerp;
        // initialRotationOffset = transform.rotation;
        initialRotationOffset = transform.rotation;
     
    }
    void Start()
    {
        // cj = GetComponent<ConfigurableJoint>();
       


    }

    void Update()
    {
      
        if (Parent_Tranform != null)
        {
            // cj.targetRotation = Quaternion.Inverse(Parent_Tranform.rotation) * transform.rotation * initialRotationOffset ;
            // cj.targetRotation = Quaternion.Inverse(Parent_Tranform.rotation) * transform.rotation  ;
            // cj.targetRotation = Parent_Tranform.rotation * initialRotationOffset;
            // Debug.Log("cc");
            // cj.targetRotation = Parent_Tranform.rotation;
            // transform.rotation = 
            // Debug.Log( Quaternion.Inverse(transform.rotation) * Parent_Tranform.rotation);
            // cj.targetRotation = Quaternion.Inverse(Parent_Tranform.rotation)* transform.rotation * initialRotationOffset ;
            if(mirrol){
                cj.targetRotation = Quaternion.Inverse(Parent_Tranform.rotation)* initialRotationOffset;
            }else{
                 cj.SetTargetRotationLocal(Parent_Tranform.rotation,initialRotationOffset);
            }
           
       
        }   

    }



    void OnDrawGizmos()
    {
        // DebugDrawDirections();
    }
    // Hàm vẽ tia để debug
    void DebugDrawDirections()
    {
        // Vị trí của Parent_Tranform và transform
        Vector3 parentPos = Parent_Tranform.position;
        Vector3 childPos = transform.position;

        // Hướng forward của Parent_Tranform (màu đỏ)
        Vector3 parentForward = Parent_Tranform.forward * 0.5f; // Nhân với 2 để tia dài hơn, dễ nhìn
        Debug.DrawRay(parentPos, parentForward, Color.red, 0.1f);

        // Hướng forward của transform (màu xanh)
        Vector3 childForward = transform.forward * 0.5f; // Nhân với 2 để tia dài hơn
        Debug.DrawRay(childPos, childForward, Color.green, 0.1f);

        // (Tùy chọn) Vẽ thêm các trục khác nếu cần
        // Trục right của Parent_Tranform (màu magenta)
        Vector3 parentRight = Parent_Tranform.right * 1f;
        Debug.DrawRay(parentPos, parentRight, Color.magenta, 0.1f);

        // Trục right của transform (màu cyan)
        Vector3 childRight = transform.right * 1f;
        Debug.DrawRay(childPos, childRight, Color.cyan, 0.1f);
    }



}
