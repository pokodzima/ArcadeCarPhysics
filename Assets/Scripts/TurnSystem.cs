using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TurnSystem : MonoBehaviour
{
    [SerializeField] private float turnRate;

    [SerializeField] private KeyCode rightKey;
    [SerializeField] private KeyCode leftKey;

    private Rigidbody _carRigidbody;
    private Vector3 _torque;
    // Start is called before the first frame update
    void Start()
    {
        _carRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _torque = Vector3.zero;

        if (Input.GetKey(rightKey))
        {
            _torque.y += turnRate;
        }

        if (Input.GetKey(leftKey))
        {
            _torque.y -= turnRate;
        }

        _carRigidbody.AddRelativeTorque(_torque);
    }
}
