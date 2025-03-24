using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class VienDan : NetworkBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag!= "Player"){
        
            // Destroy(gameObject);
            XoaObjServerRpc();
        }else{
            
        }
    }

    [ServerRpc(RequireOwnership =false)]    
    private void XoaObjServerRpc(){
        Debug.Log("Đã xóa");
        gameObject.GetComponent<NetworkObject>().Despawn();

    }

    
}
