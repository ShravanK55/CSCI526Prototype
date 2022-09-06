using System;
using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform orientation;

    [Header("Movement")]
    public float speed = 15.0f;
    public float groundDrag = 3.0f;
    public float airDrag = 1.0f;
    public float groundInputScale = 1.0f;
    public float airInputScale = 0.1f;
    public bool grounded = true;
    public LayerMask groundLayers = -1;
    [SerializeField] private float groundedDistance = 0.1f;
    private Vector3 _moveDirection;
    
    private Rigidbody _rb;
    private StarterAssetsInputs _input;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _input = GetComponent<StarterAssetsInputs>();
    }

    void FixedUpdate()
    {
        GroundedCheck();

        float inputScale = groundInputScale;
        if (grounded)
        {
            _rb.drag = groundDrag;
        }
        else
        {
            _rb.drag = airDrag;
            inputScale = airInputScale;
        }

        _moveDirection = Vector3.ClampMagnitude(orientation.forward * _input.move.y + orientation.right * _input.move.x, 1.0f);
        _rb.AddForce(_moveDirection * (speed * inputScale), ForceMode.Force);
    }
    
    private void GroundedCheck()
    {
        grounded = false;

        if (Physics.CheckSphere(transform.position, 0.25f, groundLayers))
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position + Vector3.down * groundedDistance, 0.25f);
    }
}
