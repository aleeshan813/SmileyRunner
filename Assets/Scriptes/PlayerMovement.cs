using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sprite;
    Animator anim;

    float dirX = 0;
    [SerializeField] float movSpeed = 7f;
    [SerializeField] float jumpSpeed = 14f;

    enum MovememtState { idle, running, jumping, falling}
    bool Isgrounded;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2 (dirX * movSpeed, rb.velocity.y);
        
        if (Input.GetButton("Jump") && Isgrounded)
        {
            Isgrounded = false;
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }
        updateAnimationState();
    }

    private void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.gameObject.CompareTag("Terrain"))
        {
            Isgrounded = true;
        }
    }

    private void updateAnimationState()
    {
        MovememtState state;

        if (dirX > 0)
        {
            state = MovememtState.running;
            sprite.flipX = false;
        }

        else if (dirX < 0)
        {
            state = MovememtState.running;
            sprite.flipX = true;
        }

        else
        {
            state = MovememtState.idle;
        }

        if (rb.velocity.y > 0.1f)
        {
            state = MovememtState.jumping;
        }

        else if (rb.velocity.y < -0.1f)
        {
            state = MovememtState.falling;
        }

        anim.SetInteger("State", (int)state); 
    }
}
