using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Camera_Character : MonoBehaviour
{
    public Transform camera_character;
    float mouse_X;
    float mouse_Y;


    public float stomach_offset;
    public ConfigurableJoint hipjoin,stomachJoint;

    void Start()
    {
       if (!camera_character) {camera_character = gameObject.transform;}
       Cursor.lockState = CursorLockMode.Locked;
    }

    void Update() // Chuyển sang Update() thay vì FixedUpdate()
    {
        // Lấy input và nhân với Time.deltaTime để mượt hơn
        mouse_X += Input.GetAxis("Mouse X") * Camera_Manager.Instance.rotate_speed * Time.deltaTime;
        mouse_Y -= Input.GetAxis("Mouse Y") * Camera_Manager.Instance.rotate_speed * Time.deltaTime;
        mouse_Y = Math.Clamp(mouse_Y, -35, 60); // Giới hạn góc xoay

        Quaternion rootRotate = Quaternion.Euler(mouse_Y, mouse_X, 0);

        // Dùng Slerp để mượt hơn
        camera_character.rotation = Quaternion.Slerp(camera_character.rotation, rootRotate, Time.deltaTime * 10f);
        
        // Nếu khớp vẫn giật, kiểm tra các giá trị Spring/Damper trong Inspector
        hipjoin.targetRotation = Quaternion.Euler(0, -mouse_X, 0);
        stomachJoint.targetRotation = Quaternion.Euler(-mouse_Y + stomach_offset, 0, 0);
    }


    // void FixedUpdate()
    // {
    //     mouse_X += Input.GetAxis("Mouse X") * Camera_Manager.Instance.rotate_speed;
    //     mouse_Y -= Input.GetAxis("Mouse Y") * Camera_Manager.Instance.rotate_speed;
    //     mouse_Y = Math.Clamp(mouse_Y,-35,60); //Hàm Math.Clamp(value, min, max) giới hạn một giá trị trong khoảng [min, max].

    //     Quaternion rootRotate = Quaternion.Euler(mouse_Y,mouse_X,0);

    //     camera_character.rotation  = rootRotate;
    //     hipjoin.targetRotation  = Quaternion.Euler(0,-mouse_X,0);
    //     stomachJoint.targetRotation =  Quaternion.Euler(-mouse_Y+stomach_offset,0,0);
    // }
}
