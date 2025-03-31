using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ani_char_Contronler : MonoBehaviour
{

    public Animator char_animator;
    public string boneName; // Tên xương bạn muốn lấy (ví dụ: "MyHips", "MySpine")
   
    void Start()
    {
        char_animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
            Transform boneTransform = char_animator.transform.Find(boneName);
            if (boneTransform != null)
            {
                Debug.Log( boneTransform.rotation); 
            }
    }
}
