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

    [SerializeField] private Vector3 impactPointOffset;

    private Rigidbody _carRigidbody;

    private Vector3 _groundNormal;
    private Vector3 _force;
    private Vector3 _impactPoint;
    void Start()
    {
        _carRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {   
        if (!isGrounded(out _groundNormal)) return;

        _force = Vector3.zero;

        if (Input.GetKey(accelerateKey))
        {
            _force += transform.forward * acceleration;
        }

        if (Input.GetKey(brakeKey))
        {
            _force += -transform.forward * braking;
        }

        _force = Vector3.ProjectOnPlane(_force,_groundNormal);
        _impactPoint = transform.position + transform.rotation * impactPointOffset;

        _carRigidbody.AddForceAtPosition(_force,_impactPoint);
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
