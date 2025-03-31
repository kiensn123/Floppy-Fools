using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grap_OBJ : MonoBehaviour
{

    public int Mouse;
    public Animator animator;

    public GameObject OBJ_Grap = null;

    public Rigidbody rb;

    [SerializeField]
    private bool Is_Grap = true;




    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
        if (Input.GetMouseButtonDown(Mouse)){
            if(Mouse == 0){
                animator.SetBool("TayTrai",true);
            }else{
                animator.SetBool("TayPhai",true);
            }
            Is_Grap = false;
            if(OBJ_Grap==null){return;}
            
   
        }else if(Input.GetMouseButtonUp(Mouse)){
            if(Mouse == 0){
                animator.SetBool("TayTrai",false);
            }else{
                animator.SetBool("TayPhai",false);
            }
            Is_Grap = true;

            if(OBJ_Grap!= null){
                FixedJoint fj_new = transform.gameObject.GetComponent<FixedJoint>();
                Destroy(fj_new);
                
            }
            OBJ_Grap = null;
        }
      
    }

    void OnCollisionEnter(Collision collision)
    {
        
        if(Is_Grap || OBJ_Grap!=null){    Debug.Log("Chưa được cầm"+OBJ_Grap +"Bien"+Is_Grap); return;}

        if(collision.gameObject.CompareTag("Iteam")){
            OBJ_Grap = collision.gameObject;
            FixedJoint fj_new = transform.gameObject.GetComponent<FixedJoint>();
            if (fj_new==null){
                fj_new = transform.gameObject.AddComponent<FixedJoint>();
            }


            
            fj_new.breakForce = 8000;
            fj_new.connectedBody = OBJ_Grap.GetComponent<Rigidbody>();
            fj_new.autoConfigureConnectedAnchor = false;
            fj_new.connectedAnchor = collision.transform.InverseTransformPoint(collision.GetContact(0).point);

        }
    }


}
