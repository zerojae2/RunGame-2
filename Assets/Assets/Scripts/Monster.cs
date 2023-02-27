using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float mobSpeed = 0;
    public Vector2 StartPostion;
    void Start()
    {
        transform.position = StartPostion;
    }


    void Update()
    {
        if (GameManager.instance.isPlay)
        {
            transform.Translate(Vector2.left * Time.deltaTime * GameManager.instance.gameSpeed * mobSpeed);
        }

        if (transform.position.x < -11)
        {
            gameObject.SetActive(false);
        }
    }
}
