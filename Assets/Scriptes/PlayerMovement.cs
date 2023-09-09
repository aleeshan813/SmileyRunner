using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    bool Isgrounded;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2 (dirX *7f, rb.velocity.y);
        
        if (Input.GetButtonDown("Jump") && Isgrounded)
        {
            Isgrounded = false;
            rb.velocity = new Vector2(rb.velocity.x, 10f);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.gameObject.CompareTag("Terrain"))
        {
            Isgrounded = true;
        }

    }
}
