using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handle_Grap : MonoBehaviour
{
    [SerializeField] Animator animator;
    FixedJoint fixedJoint;
    
    Rigidbody rigidbody3D;

    void Awake()
    {
        rigidbody3D = GetComponent<Rigidbody>();
        rigidbody3D.solverIterations = 100;
    }


    bool TryCarryOBJ(Collision collision){
        if (fixedJoint!=null){
            return false;
        }

        if (!collision.gameObject.TryGetComponent(out Rigidbody orterObjRigBody)){
            return false;
        }

        fixedJoint = transform.gameObject.AddComponent<FixedJoint>();

        fixedJoint.connectedBody  = orterObjRigBody;

        fixedJoint.autoConfigureConnectedAnchor = false;

        fixedJoint.connectedAnchor = collision.transform.InverseTransformPoint(collision.GetContact(0).point);





        return true;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Iteam")){return;}

        TryCarryOBJ(collision);
    }
}
