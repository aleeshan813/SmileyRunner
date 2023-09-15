using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherry : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] Points scoring;
    int point = 0;

    private void OnTriggerEnter2D(Collider2D collition)
    {

        if (collition.gameObject.CompareTag("Cherry"))
        {
            point++;
            ScoreUpdating();
            Destroy(collition.gameObject);
        }
    }
    // Update is called once per frame
    void ScoreUpdating()
    {
        scoring.UpdatePoints(point);
    }
}
