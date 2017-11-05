using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ojplayer_move : MonoBehaviour {
    public float Speed;
    Rigidbody rigidbody;
    Vector3 movement;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Run(h, v);
    }

    void Run(float h, float v)
    {
        movement.Set(h, 0, v);
        movement = movement.normalized * Speed * Time.deltaTime;

        rigidbody.MovePosition(transform.position + movement);
    }




    
}
