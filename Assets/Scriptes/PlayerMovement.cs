using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sprite;
    Animator anim;

    float dirX = 0;
    [SerializeField] GameObject PlayerCamera;
    [SerializeField] GameObject MapCamera;
    [SerializeField] float movSpeed = 7f;
    [SerializeField] float jumpSpeed = 14f;

    enum MovememtState { idle, running, jumping, falling}

    bool Isgrounded;
    bool SwitchCamera = true;

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
        updateAnimationState();
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2 (dirX * movSpeed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.C))
        {
            if (SwitchCamera)
            {
                SwitchCamera = false;
                PlayerCamera.SetActive(false);
                MapCamera.SetActive(true);
            } 
             
           else
            { 
                SwitchCamera = true; PlayerCamera.SetActive(true);
                MapCamera.SetActive(false);
            }
            
        }

        if (Input.GetButton("Jump") && Isgrounded)
        {
            AudioManager.instance.PlaySFX("Jumping");
            Isgrounded = false;
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }
  
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Terrain"))
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
