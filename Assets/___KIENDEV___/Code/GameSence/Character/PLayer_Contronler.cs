using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PLayer_Contronler : MonoBehaviour
{
    public float  speed;
    public float stafeSpeed;

    public float jumpForce;
    public bool isground;
    public Rigidbody rigidbody1;

    void Start()
    {
        rigidbody1 =  gameObject.GetComponent<Rigidbody>();
    }
    void Update()
    {

        
   
        if (Input.GetKey(KeyCode.W)){
            if (Input.GetKey(KeyCode.LeftShift)){
                rigidbody1.AddForce(rigidbody1.transform.forward*speed*1.5f);
            }else{
                rigidbody1.AddForce(rigidbody1.transform.forward*speed);
            }
        
        }
        if (Input.GetKey(KeyCode.A)){
            rigidbody1.AddForce(-rigidbody1.transform.right*speed);
    
        }
        if (Input.GetKey(KeyCode.D)){
            rigidbody1.AddForce(rigidbody1.transform.right*speed);
    
        }

        if (Input.GetKey(KeyCode.S)){
            rigidbody1.AddForce(-rigidbody1.transform.forward*speed);
    
        }

        if(Input.GetKey(KeyCode.Space)){
            if (isground){return;}

            rigidbody1.AddForce(new Vector3(0,jumpForce,0));
            isground = true;   
        }
    }
}
