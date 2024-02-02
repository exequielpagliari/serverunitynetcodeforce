using System;
using Unity.Netcode;
using UnityEngine;

public class Obstaculo : NetworkBehaviour
{
    [Range(0f, 100f)]
    public  float fuerza;
    protected Vector3 direccion;
    [SerializeField] protected AudioSource audioSource;
    [SerializeField] protected AudioClip audioClip;


    private void OnCollisionEnter(Collision collision)
    {


            direccion = (collision.transform.position - transform.position).normalized;
            if (collision.gameObject.GetComponent<ServerPhysicsMovement>() != null)
                collision.gameObject.GetComponent<ServerPhysicsMovement>().AcceptForce(direccion,fuerza);
            Debug.Log(direccion + " Direccion " + fuerza + " Fuerza ");



        
    }

    private void OnCollisionExit(Collision collision)
    {
        collision.gameObject.GetComponent<ServerPhysicsMovement>().AcceptForce(Vector3.zero, 0);
    }






}
