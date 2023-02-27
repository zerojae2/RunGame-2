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
}
