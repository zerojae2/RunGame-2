using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipScenes : MonoBehaviour
{
    public void MainSceneChange() 
    {
        SceneManager.LoadScene("MainScene");
    }
    public void InGameSceneChange() 
    {
        SceneManager.LoadScene("InGameScene");
        DataManager.Instance.StartGame(); 
    }
    public void SettingSceneChange() 
    {
        SceneManager.LoadScene("SettingScene");
    }
}
