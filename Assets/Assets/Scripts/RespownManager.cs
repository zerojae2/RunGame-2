using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespownManager : MonoBehaviour
{
    public List<GameObject> MobPool = new List<GameObject>();
    public GameObject[] Mobs;
    public int objCnt = 1;
    private void Awake()
    {
        for (int i = 0; i < Mobs.Length; i++)
        {
            for (int q = 0; q < objCnt; q++)
            {
                MobPool.Add(CreateObj(Mobs[i], transform));
            }
        }
    }

    private void Start()
    {
        GameManager.instance.onPlay += PlayGame;
        StartCoroutine(CreateMob());
    }
    void PlayGame(bool isplay) 
    {
        if (isplay)
        {
            StartCoroutine(CreateMob());
        }
        else 
        {
            StopAllCoroutines();
        }
    }
    IEnumerator CreateMob() 
    {
        while (GameManager.instance.isPlay)
        {
            MobPool[Random.Range(0, MobPool.Count)].SetActive(true);
            yield return new WaitForSeconds(Random.Range(1f, 1.5f));
        }
    }

    int DeactiveMob() 
    {
        List<int> num = new List<int>();
        for (int i = 0; i < MobPool.Count; i++) 
        {
            if (!MobPool[i].activeSelf) 
            {
                num.Add(i);
            }
        }
        int x = 0;
        if (num.Count > 0) 
        {
            x = num[Random.Range(0, num.Count)];
        }
        return x;
    }

    GameObject CreateObj(GameObject obj, Transform parent) 
    {
        GameObject copy = Instantiate(obj);
        copy.transform.SetParent(parent);
        copy.SetActive(false);
        return copy;
    }
}
    
