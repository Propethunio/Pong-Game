using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;
    [SerializeField] private TMP_Text player1ScoreText;
    [SerializeField] private TMP_Text player2ScoreText;

    private int player1Score;
    private int player2Score;

    private void Start()
    {
        player1.GetComponent<PlayerController>().isAI = GameState.p1AI;
        player1.GetComponent<PlayerController>().movementSpeed = GameState.p1Speed;
        player2.GetComponent<PlayerController>().isAI = GameState.p2AI;
        player2.GetComponent<PlayerController>().movementSpeed = GameState.p2Speed;
    }

    public void Player1Score()
    {
        player1Score++;
        player1ScoreText.text = player1Score.ToString();
    }

    public void Player2Score()
    {
        player2Score++;
        player2ScoreText.text = player2Score.ToString();
    }
}