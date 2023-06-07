using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown player1Setting;
    [SerializeField] private TMP_Dropdown player2Setting;
    [SerializeField] private Toggle gravityMode;
    [SerializeField] private float playerSpeed = 10f;
    [SerializeField] private float easy = 7f;
    [SerializeField] private float medium = 9f;
    [SerializeField] private float hard = 11f;

    private void Start()
    {
        StartSettings();
        player1Setting.onValueChanged.AddListener(delegate
        {
            player1SettingChange(player1Setting);
        });
        player2Setting.onValueChanged.AddListener(delegate
        {
            player2SettingChange(player2Setting);
        });
        gravityMode.onValueChanged.AddListener(delegate
        {
            GravityToggleChange(gravityMode);
        });
    }

    public void NewGamePlay(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void StartSettings()
    {
        player1SettingChange(player1Setting);
        player2SettingChange(player2Setting);
        GravityToggleChange(gravityMode);
    }

    private void player1SettingChange(TMP_Dropdown sender)
    {
        if (sender.value == 0)
        {
            GameState.p1AI = false;
            GameState.p1Speed = playerSpeed;
        }
        else if (sender.value == 1)
        {
            GameState.p1AI = true;
            GameState.p1Speed = easy;
        }
        else if (sender.value == 2)
        {
            GameState.p1AI = true;
            GameState.p1Speed = medium;
        }
        else
        {
            GameState.p1AI = true;
            GameState.p1Speed = hard;
        }
    }

    private void player2SettingChange(TMP_Dropdown sender)
    {
        if (sender.value == 0)
        {
            GameState.p2AI = false;
            GameState.p2Speed = playerSpeed;
        }
        else if (sender.value == 1)
        {
            GameState.p2AI = true;
            GameState.p2Speed = easy;
        }
        else if (sender.value == 2)
        {
            GameState.p2AI = true;
            GameState.p2Speed = medium;
        }
        else
        {
            GameState.p2AI = true;
            GameState.p2Speed = hard;
        }
    }

    private void GravityToggleChange(Toggle sender)
    {
        if (sender.isOn)
        {
            GameState.gravityMode = true;
        }
        else
        {
            GameState.gravityMode = false;
        }
    }
}