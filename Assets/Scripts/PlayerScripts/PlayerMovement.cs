using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float moveSpeed = 10f;
    private Vector3 movement;

    // Update is called once per frame
    void Update()
    {
        movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
    }

    void FixedUpdate()
    {
        transform.position += movement * Time.fixedDeltaTime * moveSpeed;
    }
}
