using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityTrigger : MonoBehaviour
{
    private void Start()
    {
        if (!GameState.gravityMode)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        float random = Random.value;
        if (random > .666f)
        {
            collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
        else if (random < .333f)
        {
            collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = -1;
        }
        else
        {
            collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        }
    }
}