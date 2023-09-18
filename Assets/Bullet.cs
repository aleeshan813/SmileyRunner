using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 20f;
    [SerializeField] Rigidbody2D rb;

    // Start is called before the first frame update
    private void Start()
    {
       rb.velocity = transform.right * speed;
        AudioManager.instance.PlaySFX("Throw");
    }
    private void OnTriggerEnter2D(Collider2D HitInfo)
    {
        if(HitInfo.gameObject.CompareTag("Enemy"))
        {
            Enemy enmey = HitInfo.GetComponent<Enemy>();
            if(enmey != null) 
            {
                enmey.Health -= 30;
            }
        }
        Destroy(gameObject);
    }
}
