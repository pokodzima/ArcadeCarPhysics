using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CarEngine : MonoBehaviour
{
    [SerializeField] private float acceleration;
    [SerializeField] private float braking;

    [SerializeField] private KeyCode accelerateKey;
    [SerializeField] private KeyCode brakeKey;

    private Rigidbody _carRigidbody;
    void Start()
    {
        _carRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 groundNormal;
        
        if (!isGrounded(out groundNormal)) return;

        if (Input.GetKey(accelerateKey))
        {
            Vector3 accelereationForce = transform.forward * acceleration;
            accelereationForce = Vector3.ProjectOnPlane(accelereationForce, groundNormal);
            _carRigidbody.AddForce(accelereationForce);
        }

        if (Input.GetKey(brakeKey))
        {
            Vector3 brakingForce = -transform.forward * braking;
            brakingForce = Vector3.ProjectOnPlane(brakingForce,groundNormal);
            _carRigidbody.AddForce(brakingForce);
        }
    }

    private bool isGrounded(out Vector3 groundNormal)
    {
        Ray ray = new Ray();
        ray.direction = -transform.up;
        ray.origin = transform.position;
        RaycastHit raycastHit;
        
        if (Physics.Raycast(ray,out raycastHit))
        {
            groundNormal = raycastHit.normal;
            return true;
        }
        else
        {
            groundNormal = Vector3.zero;
            return false;
        }
    }
}
