using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [HideInInspector] public float movementSpeed;
    [HideInInspector] public bool isAI;
    [SerializeField] private KeyCode upKey;
    [SerializeField] private KeyCode downKey;
    [SerializeField] private GameObject ball;

    private Rigidbody2D rb;
    private Vector2 moveDirection;

    private void Start()
    {
        rb= GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isAI)
        {
            AiControl();
        }
        else
        {
            PlayerControl();
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = moveDirection * movementSpeed;
    }

    private void PlayerControl()
    {
        if (Input.GetKey(upKey))
        {
            moveDirection = new Vector2(0, 1).normalized;
        }
        else if (Input.GetKey(downKey))
        {
            moveDirection = new Vector2(0, -1).normalized;
        }
        else
        {
            moveDirection = new Vector2(0, 0).normalized;
        }
    }

    private void AiControl()
    {
        if (ball.transform.position.y > transform.position.y + .5f)
        {
            moveDirection = new Vector2(0, 1).normalized;
        }
        else if (ball.transform.position.y < transform.position.y - .5f)
        {
            moveDirection = new Vector2(0, -1).normalized;
        } 
        else
        {
            moveDirection = new Vector2(0, 0).normalized;
        }
    }
}