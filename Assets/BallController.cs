using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private GameManager Manager;
    [SerializeField] private float initialSpeed;
    [SerializeField] private float speedIncrease;

    private int hitCounter;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(StartBall());
    }

    private void MoveBall(Vector2 direction)
    {
        direction = direction.normalized;
        float ballSpeed = initialSpeed + speedIncrease * hitCounter;
        rb.velocity = direction * ballSpeed;
    }

    private IEnumerator StartBall()
    {
        yield return new WaitForSeconds(1);

        float directionX = Random.Range(.5f, 1f);
        float directionY = Random.Range(-1f, 1f);
        if (Random.value > .5f)
        {
            directionX *= -1;
        }
        MoveBall(new Vector2(directionX, directionY));
    }

    private void Bounce(Collision2D collision)
    {
        hitCounter++;
        Vector3 ballPosition = transform.position;
        Vector3 playerPosition = collision.transform.position;
        float playerHeight = collision.collider.bounds.size.y;

        float positionX;
        if(collision.gameObject.name == "Player1")
        {
            positionX = 1;
        }
        else
        {
            positionX = -1;
        }
        float positionY = (ballPosition.y - playerPosition.y) / playerHeight;
        MoveBall(new Vector2(positionX, positionY));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player1" ||  collision.gameObject.name == "Player2")
        {
            Bounce(collision);
        }
        else if(collision.gameObject.name == "Border_R")
        {
            Manager.Player1Score();
            ResetBall();
        }
        else if(collision.gameObject.name == "Border_L")
        {
            Manager.Player2Score();
            ResetBall();
        }
    }

    private void ResetBall()
    {
        hitCounter = 0;
        transform.position = new Vector2(0, 0);
        rb.velocity = new Vector2(0, 0);
        rb.gravityScale = 0;
        StartCoroutine(StartBall());
    }
}