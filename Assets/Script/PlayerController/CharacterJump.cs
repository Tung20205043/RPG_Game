using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJump : MonoBehaviour
{
    public float jumpForce = 10f;

    private Rigidbody rb;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space) /*&& isGrounded*/) {
            Debug.Log("jumop");
            DoJump();
        }
    }

    public void DoJump() {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z); 
    }
}
