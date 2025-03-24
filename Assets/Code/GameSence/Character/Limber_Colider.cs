using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limber_Colider : MonoBehaviour
{
    public PLayer_Contronler pLayer_Contronler;

    void Start()
    {
        // pLayer_Contronler = GameObject.FindObjectOfType<PLayer_Contronler>().GetComponent<PLayer_Contronler>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        pLayer_Contronler.isground = false;
    }
}
