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
        if (Input.GetKey(accelerateKey))
        {
            Vector3 accelereationForce = transform.forward * acceleration;
            _carRigidbody.AddForce(accelereationForce);
        }

        if (Input.GetKey(brakeKey))
        {
            Vector3 brakingForce = -transform.forward * braking;
            _carRigidbody.AddForce(brakingForce);
        }
    }
}
