using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    static DataManager instance;
    public static DataManager Instance 
    {
        get 
        {
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
    }
    private void Update()
    {
        
    }

    public int coin = 0;
    public int score = 0;
    public int highScore = 0;

    public int delay;
    public int timer;


    Coroutine playing;

    public void StartGame() //������ ���۵Ǿ�����
    {
        if (playing == null)
        {
            score = 0;
            playing = StartCoroutine(PlayAddScore());
        }
        else
        {
            StopCoroutine(playing);
        }
    }

    public void FinishGame()  //������ ��������
    {
        if (playing != null)
        {
           

            saveScore();

            StopCoroutine(playing);
            playing = null;
        }
    }




    public void saveScore() //������ �ְ��������� ������ �ְ������� ��ϵ�
    { 
        if (this.score > this.highScore) 
        {
            this.highScore = this.score;
        }
    }

    private IEnumerator PlayAddScore() //�ð��� ���� ��������
    {
        while (true)
        {
            score += 1;
            yield return new WaitForSeconds(0.09f);
        }
    }

    public void InitializeData()
    {
        instance.score = 0;
        instance.highScore = 0;
        instance.coin = 0;
    }
    public void InitializeScore()
    {
        instance.score = 0;
        instance.highScore = 0;
    }
}

