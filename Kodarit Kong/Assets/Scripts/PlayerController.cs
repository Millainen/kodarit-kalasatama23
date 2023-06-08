using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // viittaus rigidbodyyn 
    private Rigidbody2D player;

    float horizontalInput;

    float verticalInput;

    // suunta
    private Vector2 movement;

    // nopeus
    public float moveSpeed = 5f;

    //hyppyvoima
    public float jumpForce = 4f;

    //osuuko maahan
    private bool grounded;
    
    private bool canClimb = false;
    private bool isClimbing = false;

    private Transform ladder;
    private float playerHeight;

    // start funktio
    void Start()
    {
        // haetaan rigidbody pelaajasta
        player = GetComponent<Rigidbody2D>();
        playerHeight = GetComponent<SpriteRenderer>().size.y;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        
        

        if (Input.GetKeyDown("space") && grounded)
        {
            //hyppää
            player.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        if (canClimb)//jos pystyy kiipeämään
        { 
            if (verticalInput != 0)//jos ylös-alas nappeja painetaan
            {
                isClimbing = true; //kiipeämistila on tosi
            }
        } else {/////////
            isClimbing = false;//////////
        }///////////

        if (isClimbing){
            player.isKinematic = true;
            movement.y = verticalInput * moveSpeed;
            player.position = new Vector2(ladder.transform.position.x, player.position.y);
        } else {/////////
            player.isKinematic = false;//////////////////
        }///////



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

        if (collision.gameObject.CompareTag("Ladder"))
        {
            canClimb = true; //jos ollaan tikapuiden kohdalla, niin pystyy kiipeämään
            ladder = collision.transform; //laitetaan muistiin mistä tikapuusta on kyse
            Debug.Log("tassa on ladder");
        }
    }
    
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            grounded = false;
            //ei ole kiinni maassa
        }
        if (collision.gameObject.CompareTag("Ladder"))
        {
            canClimb = false;
            Debug.Log("ei ole ladderia");
        }
    }
}
