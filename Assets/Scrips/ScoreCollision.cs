using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            //Player.Instance.PlayerScore();
            PlayerController.Instance.BadCollision();
            Destroy(collision.gameObject);
        }
    }
}
