using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour
{
    public float moveSpeed = 5f;   // Tốc độ di chuyển tiến/lùi
    public float rotateSpeed = 100f; // Tốc độ xoay
    public float jumpForce = 5f;   // Lực nhảy
    private Rigidbody rb;
    private Animator ani;

    [Header("Ramdom")]

    [SerializeField]private float range =5 ;
    // [SerializeField] private List<Color> mauxac;
    [SerializeField] private Vector3 toadoramdom;

    private NetworkVariable<Color> playerColor = new NetworkVariable<Color>(
        default, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);

    private MeshRenderer meshRenderer;


    void Awake()  //Hàm này chạy đầu tiên 
    {
         meshRenderer = GetComponent<MeshRenderer>();
    }

    
    public override void OnNetworkSpawn()  //Hàm này chạy thứ 2
    {
         
        Debug.Log(meshRenderer);
        ApplyColor(playerColor.Value);
        // playerColor.OnValueChanged += ApplyColor=>  ApplyColor(default, playerColor.Value);
        playerColor.OnValueChanged += (oldColor, newColor) => ApplyColor(newColor);
      
        if(!IsOwner){return;}
        Vector3 newtoado =  new Vector3(Random.Range(toadoramdom.x-range,toadoramdom.x+range),toadoramdom.y,Random.Range(toadoramdom.z-range,toadoramdom.z+range));
        // int Ramdom = Random.Range(0,materials.l)
        Color mausac = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f);
        transform.position = newtoado;
        meshRenderer.materials[0].color = mausac;
        playerColor.Value = mausac;

   
    }

    private void ApplyColor(Color newColor)
    {
        // Áp dụng màu cho MeshRenderer
        if (meshRenderer != null)
        {
            meshRenderer.materials[0].color = newColor;
        }
    }

    public override void OnNetworkDespawn()
    {
         Debug.Log("Đã xóa tạo obj");
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Lấy Rigidbody
        ani = GetComponent<Animator>();
      
    }

    void Update()
    {
        if(!IsOwner) return; // nếu ko phải chủ sở hữu
          // Xoay nhân vật bằng phím A/D
        float rotation = Input.GetAxis("Horizontal"); // A/D
        transform.Rotate(0, rotation * rotateSpeed * Time.deltaTime, 0);

        // Di chuyển tiến/lùi bằng phím W/S
        float moveZ = Input.GetAxis("Vertical"); // W/S
        if(moveZ!=0){
            ani.SetFloat("TocDo",1);
        }else{
             ani.SetFloat("TocDo",0);
        }
        Vector3 movement = transform.forward * moveZ * moveSpeed * Time.deltaTime;
        rb.MovePosition(transform.position + movement);
        

        // Nhảy khi nhấn Space
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
