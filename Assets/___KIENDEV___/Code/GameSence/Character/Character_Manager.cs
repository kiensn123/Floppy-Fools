using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class Character_Manager : MonoBehaviour
{
    [Header("OBJ_Contronler")]

    [SerializeField]
    private Rigidbody Humanoid;

    [Header("Properties")]
    [SerializeField]
    private float Speed;

    [SerializeField]
    private  float horizon;
    [SerializeField]
    private float vetical;



    [Header("Jum")]
    public bool IsJump;
    public GameObject ChanDuoi;
    public Vector3 Size;
    public Vector3 Offset;
    public LayerMask layerMask;

    public float jumpForce;

    [Header("Animation")]
    public Animator animator;

    void Start()
    {
        // BoxCollider ChanDuoicolider = ChanDuoi.GetComponent<BoxCollider>();
        // Size = ChanDuoicolider.size;
        
    }


    void Update()
    {

        // if(Input.GetMouseButtonDown(0)){
        //     animator.SetBool("TayTrai",true);
        // }
        // if(Input.GetMouseButtonUp(0)){
        //     animator.SetBool("TayTrai",false);
        // }
        //  if(Input.GetMouseButtonDown(1)){
        //     animator.SetBool("TayPhai",true);
        // }
        // if(Input.GetMouseButtonUp(1)){
        //     animator.SetBool("TayPhai",false);
        // }
        // if (!IsOwner){return;}
        if (Humanoid.isKinematic)  
        {
            Humanoid.isKinematic = false; // Chắc chắn Rigidbody không ở chế độ Kinematic
        }

        Move();
        Jump();
        
    }



    /// <summary>
    /// Di chuyển của người chơi
    /// </summary>
    void Move(){

        horizon = Input.GetAxis("Horizontal");
        vetical = Input.GetAxis("Vertical");
        animator.SetFloat("Trc_Sau",vetical);
        animator.SetFloat("Trai_Phai",horizon);

        float tocdo = Speed;
        // if (vetical<0){tocdo = Speed/1.5f;}

        Vector3 moveDirection = (Humanoid.transform.forward * vetical + Humanoid.transform.right * horizon).normalized;
        //normalized khi bạn cần giữ nguyên hướng nhưng đảm bảo độ dài vector luôn là 1

        Humanoid.velocity = new Vector3(moveDirection.x * tocdo, Humanoid.velocity.y, moveDirection.z * tocdo);
    }


    /// <summary>
    /// Chức năng nhảy 
    /// </summary>
    void Jump(){
        if (Input.GetKeyDown(KeyCode.Space)){

            bool isground = Physics.CheckBox(ChanDuoi.transform.position+Offset,Size/2,Quaternion.identity,layerMask);
            if (!isground ){return;}
            IsJump = true;
            Humanoid.AddForce(new Vector3(0,jumpForce,0));
        }
    }

    void OnDrawGizmos()
    {
    //    Gizmos.DrawCube(ChanDuoi.transform.position,Size);
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(ChanDuoi.transform.position+Offset,Size);
       
    }

   


}
