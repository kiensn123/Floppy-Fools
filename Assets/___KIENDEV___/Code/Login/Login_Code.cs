using System.Threading.Tasks;
using Firebase;
using Firebase.Auth;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Login_Code : MonoBehaviour
{
    [Header("Input")]
    [SerializeField] public TMP_InputField email;
    [SerializeField] public TMP_InputField password;

    [Header("Button")]
    public Button Submit;

    private FirebaseAuth auth;

    void Start()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            var dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available)
            {

                auth = FirebaseAuth.DefaultInstance;
            
                Submit.onClick.AddListener(Login_Do);
                Debug.Log("Firebase initialized successfully.");
            }
            else
            {
                Debug.LogError($"Firebase initialization failed: {dependencyStatus}");
            }
        });
    }

    public async void Login_Do()
    {
        if (string.IsNullOrEmpty(email.text) || string.IsNullOrEmpty(password.text))
        {
            Debug.LogError("Email or password is empty.");
            return;
        }

        Debug.Log($"Attempting login with email: {email.text}");
        bool success = await this.Login_FireBase_KDev( auth);
        Debug.Log($"Login result: {success}");
    }

  
}