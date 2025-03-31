using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Firebase.Auth;
using System.Threading.Tasks;
using JetBrains.Annotations;

public class Register_Code : MonoBehaviour
{
   
    [Header("Input")]
    [SerializeField] public TMP_InputField user_name;
    [SerializeField] public TMP_InputField email;
    [SerializeField] public TMP_InputField password;
    [SerializeField] public TMP_InputField Re_password;


    [Header("Button")]
    public Button Register_Submit;

    [Header("firebase")]
    private FirebaseAuth auth;

    void Start()
    {
        auth = FirebaseAuth.DefaultInstance;    
        Register_Submit.onClick.AddListener(Register_Do);
    }


    public async void Register_Do(){
      
        FirebaseAuth auth = await Account_Management.FireBaseAuth_KDev();
        bool state =  await this.Regiser_FireBase_KDev(auth);
        if (state == false){
            Debug.LogError("Lỗi khi đăng nhập");
        }
    }

    public bool Condition(){
        return true;
    }

    
}
