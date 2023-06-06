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

    //hyppyvoima
    public float jumpForce = 4f;

    //osuuko maahan
    private bool grounded;

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
        if (Input.GetKeyDown("space") && grounded)
        {
            //hyppää
            player.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        movement.x = horizontalInput * moveSpeed;
    }

    void FixedUpdate()
    {
        player.position += movement * Time.deltaTime;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            grounded = true;
            //on kiinni maassa
        }
    }
    
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            grounded = false;
            //ei ole kiinni maassa
        }
    }
}
