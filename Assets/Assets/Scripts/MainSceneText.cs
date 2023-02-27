using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneText : MonoBehaviour
{
    [SerializeField] private Text highScoretxt;

    private void Update()
    {
        int highScore = DataManager.Instance.highScore;
        highScoretxt.text = "�ְ� ���� : " + highScore.ToString();
    }
}
