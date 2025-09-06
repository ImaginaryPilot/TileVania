using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [SerializeField] float runspeed = 5f;
    [SerializeField] float jumpspeed = 5f;
    [SerializeField] float climbspeed = 5f;
    [SerializeField] Vector2 deathkick = new Vector2(-5, 5);
    [SerializeField] bool isAlive = true;
    Rigidbody2D myrigidbody;
    Animator myanimator;
    CapsuleCollider2D Mybodycollider;
    BoxCollider2D Myfeet;
    float gravityscaleatstart;
    void Start()
    {
        myrigidbody = GetComponent<Rigidbody2D>();
        myanimator = GetComponent<Animator>();
        Mybodycollider = GetComponent<CapsuleCollider2D>();
        Myfeet = GetComponent<BoxCollider2D>();
        gravityscaleatstart = myrigidbody.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive) { return; }
            Run();
            FlipSprite();
            Jump();
            Climbing();
        Die();
    }

    void Run()
    {
        float controlthrow = CrossPlatformInputManager.GetAxis("Horizontal");
        Vector2 playervelocity = new Vector2(controlthrow * runspeed, myrigidbody.velocity.y);
        myrigidbody.velocity = playervelocity;
        bool playerrunning = Mathf.Abs(myrigidbody.velocity.x) > Mathf.Epsilon;
        myanimator.SetBool("Running", playerrunning);
    }

    void Jump()
    {
        if (CrossPlatformInputManager.GetButtonDown("Jump") && Myfeet.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            Vector2 Jumpvelocity = new Vector2(0f, jumpspeed);
            myrigidbody.velocity += Jumpvelocity; 
        }
    }

    void Climbing()
    {
        if (!Mybodycollider.IsTouchingLayers(LayerMask.GetMask("Ladders"))) {
            myanimator.SetBool("Climbing", false);
            myrigidbody.gravityScale = gravityscaleatstart;
            return;
        }
        float controlthrow = CrossPlatformInputManager.GetAxis("Vertical");
        Vector2 playervelocity = new Vector2(myrigidbody.velocity.x,controlthrow * climbspeed);
        myrigidbody.velocity = playervelocity;
        myrigidbody.gravityScale = 0f;
        bool playerhasverticalspeed = Mathf.Abs(myrigidbody.velocity.y) > Mathf.Epsilon;
        myanimator.SetBool("Climbing", playerhasverticalspeed);
    }

    private void FlipSprite()
    {
        bool playerhorizspeed = Mathf.Abs(myrigidbody.velocity.x) > Mathf.Epsilon;
        if (playerhorizspeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(myrigidbody.velocity.x), 1f);
        }
    }

    private void Die()
    {
        if (Mybodycollider.IsTouchingLayers(LayerMask.GetMask("Enemy", "Hazards")) || Myfeet.IsTouchingLayers(LayerMask.GetMask("Hazards")))
        {
            isAlive = false;
            myanimator.SetTrigger("Die");
            GetComponent<Rigidbody2D>().velocity = deathkick;
            FindObjectOfType<GameSession>().PlayerLostLife();
        }
    }
}
