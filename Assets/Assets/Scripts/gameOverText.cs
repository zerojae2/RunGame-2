using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameOverText : MonoBehaviour
{
    [SerializeField] private Text Scoretxt;

        private void Update()
    { 
        Scoretxt.text = "Á¡¼ö : " + DataManager.Instance.score.ToString();
    }
}
