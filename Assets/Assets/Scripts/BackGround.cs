using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    private MeshRenderer render;

    public float speed;
    private float offset;

    private void Start()
    {
        render = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        offset += Time.deltaTime * speed;
        render.material.mainTextureOffset = new Vector2(offset, 0);
    }
}

