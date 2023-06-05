using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // viittaus rigidbodyyn 
    private Rigidbody2D player;

    float horizontalInput;

    // suunta
    private Vector2 movement;

    // nopeus
    public float moveSpeed = 5f;

    // start funktio
    void Start()
    {
        // haetaan rigidbody pelaajasta
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        movement.x = horizontalInput * moveSpeed;
    }

    void FixedUpdate()
    {
        player.position += movement * Time.deltaTime;
    }
    
}
