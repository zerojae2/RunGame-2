using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    public delegate void OnPlay(bool isplay);
    public OnPlay onPlay;

    private Monster monster;
    public float gameSpeed = 1;
    public bool isPlay = false;  

    public void GameOver() 
    {
        isPlay = false;
        onPlay.Invoke(isPlay);
    }

    private void Update()
    {
        switch (DataManager.Instance.score)
        {
            case 100:
                gameSpeed = 8.5f;
                break;
            case 200:
                gameSpeed = 9;
                break;
            case 300:
                gameSpeed = 9.5f;
                break;
            case 400:
                gameSpeed = 10;
                break;
            case 500:
                gameSpeed = 10.5f;
                break;
            case 600:
                gameSpeed = 11f;
                break;
            case 700:
                gameSpeed = 11.5f;
                break;
            case 800:
                gameSpeed = 12f;
                break;
            case 900:
                gameSpeed = 12.5f;
                break;
            case 1000:
                gameSpeed = 13f;
                break;
            case 1100:
                gameSpeed = 13.5f;
                break;
            case 1200:
                gameSpeed = 14f;
                break;
            case 1300:
                gameSpeed = 14.5f;
                break;
            case 1400:
                gameSpeed = 15f;
                break;
            case 1500:
                gameSpeed = 15.5f;
                break;
            case 1600:
                gameSpeed = 16f;
                break;
            case 1700:
                gameSpeed = 16.5f;
                break;
            case 1800:
                gameSpeed = 17f;
                break;
            case 1900:
                gameSpeed = 17.5f;
                break;
            case 2000:
                gameSpeed = 18f;
                break;
        }
    }

}
