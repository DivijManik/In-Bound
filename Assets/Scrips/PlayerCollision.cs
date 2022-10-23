using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Ball"))
    //    {
    //        Player.Instance.BadCollision();
    //    }
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Ball"))
        {
            //collision.transform.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            PlayerController.Instance.PlayerScore();
        }
    }
}
