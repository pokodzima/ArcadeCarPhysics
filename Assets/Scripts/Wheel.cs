using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    [SerializeField] private float suspensionLenght;
    [SerializeField] private float suspensionStiffness;
    [SerializeField] private float suspensionDampening;

    [SerializeField] private Rigidbody carRigidbody;
   
    private Ray _ray;
    private RaycastHit _raycastHit;
    
    void FixedUpdate()
    {
        _ray.origin = transform.position;
        _ray.direction = -transform.up;
        if (Physics.Raycast(_ray, out _raycastHit ))
        {
            Vector3 speedAtPoint = carRigidbody.GetPointVelocity(transform.position);
            Vector3 suspensionForce = transform.up *
                (suspensionLenght - _raycastHit.distance) *
                suspensionStiffness -
                (speedAtPoint * suspensionDampening);
            carRigidbody.AddForceAtPosition(suspensionForce,transform.position);       
        }   
    }

    private void OnDrawGizmos() {
        Gizmos.DrawSphere(transform.position,suspensionLenght);
    }
}
