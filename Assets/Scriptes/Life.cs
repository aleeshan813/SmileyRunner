using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour
{
    [SerializeField] Image[] HealthImg;
    [SerializeField] Image special;
    [SerializeField] GameObject ExitPanel;

    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator Player_anim;
    

    // Keeps track of the current health.
    private int currentHealth;
    bool healed;

    private void Start()
    {
        // Initialize the current health to the total number of health images.
        currentHealth = HealthImg.Length;
        // Enable all health images at the start.
        EnableAllHealthImages();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            AudioManager.instance.PlaySFX("Lost");
            // Reduce health when colliding with an enemy.
            TakeDamage();
        }

        if (collision.gameObject.CompareTag("Life"))
        {
            // Increase health when colliding with a health pickup.
            Heal();

            if (healed == true)
            {
                Destroy(collision.gameObject);
            }
           
        }
    }

    // Function to handle taking damage (disabling health images).
    private void TakeDamage()
    {
        if (currentHealth > 0)
        {
            // Disable one health image.
            HealthImg[currentHealth - 1].enabled = false;
            currentHealth--;
           

            if (currentHealth == 0)
            {
                Player_anim.SetTrigger("Deth");
                rb.bodyType = RigidbodyType2D.Static;
            }
        }
    }

    // Function to handle healing (enabling health images).
    private void Heal()
    {
        if (currentHealth < HealthImg.Length)
        {
            healed = true;
            // Enable one health image.
            HealthImg[currentHealth].enabled = true;
            currentHealth++;      
        }
        else
        {
            healed = false;
        }
    }

    // Enable all health images.
    private void EnableAllHealthImages()
    {
        for (int i = 0; i < HealthImg.Length; i++)
        {
            HealthImg[i].enabled = true;
        }
    }
    void ExitPanelactive()
    {
        AudioManager.instance.PlaySFX("GameOver");
        ExitPanel.SetActive(true);
    }
}
