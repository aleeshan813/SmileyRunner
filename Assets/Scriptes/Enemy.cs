using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer sr;

    public int Health = 90;

    [SerializeField] GameObject Player;
    [SerializeField] BoxCollider2D Palyer_box;
    [SerializeField] Animator Player_anim;
    [SerializeField] Rigidbody2D Player_rb;

    [SerializeField] GameObject Waypoints_1;
    [SerializeField] GameObject Waypoints_2;

    Transform CurrentPosition;

    [SerializeField] float speed = 2.0f;
    [SerializeField] float detectionRadius = 5.0f; // Radius for player detection

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        CurrentPosition = Waypoints_2.transform;

        anim.SetBool("isRunning", true);
    }

    // Update is called once per frame
    void Update()
    {

        TakeDamage();

        Vector2 point = CurrentPosition.position - transform.position;

        // Check if the player is within the detection radius
        if (Vector2.Distance(transform.position, Player.transform.position) < detectionRadius)
        {
            flip();
            // Enemy should follow the player
            Vector2 direction = (Player.transform.position - transform.position).normalized;
            rb.velocity = new Vector2(direction.x * speed, 0);
        }

        else
        {
            // Enemy follows waypoints when player is not detected
            if (CurrentPosition == Waypoints_2.transform)
            {
                rb.velocity = new Vector2(speed, 0);
            }
            else
            {
                rb.velocity = new Vector2(-speed, 0);
            }

            // Check if the enemy has reached a waypoint
            if (Vector2.Distance(transform.position, CurrentPosition.position) < 0.5f && CurrentPosition == Waypoints_2.transform)
            {
                flip();
                CurrentPosition = Waypoints_1.transform;
            }
            if (Vector2.Distance(transform.position, CurrentPosition.position) < 0.5f && CurrentPosition == Waypoints_1.transform)
            {
                flip();
                CurrentPosition = Waypoints_2.transform;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Player_anim.SetTrigger("Deth");
            Palyer_box.enabled = false;
        }
    }

    void flip()
    {
        transform.Rotate(0f, 180f, 0f);
    }

    public void TakeDamage()
    {
        if(Health <= 0)
        {
            anim.SetTrigger("Deth");
        }
    }

    public void Died()
    {
        Destroy(transform.parent.gameObject);

    }
}
