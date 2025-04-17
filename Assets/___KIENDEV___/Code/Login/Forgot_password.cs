using System.Collections;
using System.Collections.Generic;
using Firebase.Auth;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Forgot_password : MonoBehaviour
{
   
    [Header("Input")]
    [SerializeField] public TMP_InputField email;

    [Header("Button")]
    public Button Submit;

    private FirebaseAuth auth;

    void Start()
    {
        auth = FirebaseAuth.DefaultInstance;
        Submit.onClick.AddListener(Forgot_password_Do);
    }

    public async void  Forgot_password_Do()
    {
        bool success = await this.Forgot_password_FireBase_KDev(auth);

        if (success){
            Debug.Log("Đã gửi gmail reset ");
        }else{
             Debug.Log("Lỗi khi gửi ");
        }
    }

    



}
