using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    private SpriteRenderer sprite;
    float dirX = 0f;
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float jumpForce = 4f;
    [SerializeField] private LayerMask jumpGround;
    // Start is called before the first frame update
    private enum moveState { idle, running, jumping, falling };
    // private moveState state = moveState.idle;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {

        dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        updateAnimation();
    }
    private void updateAnimation()
    {
        // checking for each moving state of player
        moveState state;
        // change in horizontal direction => running
        if (dirX > 0f)
        {
            state = moveState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = moveState.running;
            sprite.flipX = true;
        }
        else
        {
            state = moveState.idle;
        }
        // check for jumping or falling 
        if (rb.velocity.y > .1f)
        {
            state = moveState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = moveState.falling;
        }
        anim.SetInteger("state", (int)state);
    }
    // the function check for touching the ground or not => jumping only one at a time 
    private bool isGrounded()
    {
        // check the box collider of character whether it is overlap with the jumGround or not (move the box collider a little bit lower so it could be overlap with the ground)
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpGround);
    }
}
