using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class ShootBall : NetworkBehaviour
{
    public GameObject ballPrefab; // Prefab của quả bóng (tạo trước trong Unity)
    public Transform spawnPoint;  // Vị trí bắn (có thể là tay nhân vật)
    public float ballSpeed = 10f; // Tốc độ quả bóng

    void Update()
    {
        // Bắn khi nhấn phím F
        if (Input.GetKeyDown(KeyCode.F))
        {
          
            Shoot();
        }
    }

   
    void Shoot()
    {
        if(!IsOwner){return;}
        // Tạo quả bóng tại vị trí spawnPoint

        Vector3 shootDirection = spawnPoint.forward;
        Vector3 Toado = spawnPoint.position;
        TaoDanServerRpc(shootDirection,Toado);
    }

    [ServerRpc(RequireOwnership =false)] 
    private void TaoDanServerRpc(Vector3 shootDirection, Vector3 postionbong){  /// sEver để tạo đạn  bắt buộc phải có đuôi ServerRpc
        GameObject ball = Instantiate(ballPrefab, postionbong, spawnPoint.rotation);
        ball.GetComponent<NetworkObject>().Spawn();
        // Thêm lực để quả bóng bay về phía trước
        Rigidbody ballRb = ball.GetComponent<Rigidbody>();
        ballRb.velocity = shootDirection.normalized * ballSpeed;
    }
}
