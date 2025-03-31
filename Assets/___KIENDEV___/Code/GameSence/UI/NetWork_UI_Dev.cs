using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class NetWork_UI_Dev : NetworkBehaviour
{


   
    [SerializeField] private Button Sever_button;
    
    [SerializeField]
    private Button Host_button;
    
    [SerializeField]
    private Button Client_button;

    [SerializeField]
    private Text Playercout;

    private NetworkVariable<int> playerNum = new NetworkVariable<int>(0,NetworkVariableReadPermission.Everyone);



    void Start()
    {
        Sever_button.onClick.AddListener(Sever_click);
        Host_button.onClick.AddListener(Host_click);
        Client_button.onClick.AddListener(Client_click);
    }

    /// hàm này sẽ chạy sever
    public void Sever_click(){
        NetworkManager.Singleton.StartServer();
    }

    /// hàm này sẽ chạy sever
    public void Host_click(){
        NetworkManager.Singleton.StartHost();
    }

    /// hàm này sẽ chạy sever
    public void Client_click(){
        NetworkManager.Singleton.StartClient();
    }



    private void Update()
    {
        Playercout.text = "PlayerNum" + playerNum.Value.ToString()    ;
        if(!IsServer){return;}
        playerNum.Value = NetworkManager.Singleton.ConnectedClients.Count;
      
    }
}
