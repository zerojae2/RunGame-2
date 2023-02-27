using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUIManager : MonoBehaviour
{
    [SerializeField] private Text Scoretxt;

    private void Update()
    {
        Scoretxt.text = "Á¡¼ö : " + DataManager.Instance.score.ToString();
    }

}
