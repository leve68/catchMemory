using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField]
    [Range(-1.0f, 1.0f)]
    private float moveSpeed = 0.1f;
    private Material material;
    private Vector2 vector;

    private PlayerControl playerUI;



    private void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        playerUI = GameObject.FindWithTag("UI").GetComponentInChildren<PlayerControl>();
        vector = material.GetTextureOffset("_MainTex");
        if (playerUI.isMovingLeft || Input.GetKey(KeyCode.A))
        {
            material.SetTextureOffset("_MainTex", new Vector2(vector.x + moveSpeed / 100, vector.y));
        }
        else if (playerUI.isMovingRight || Input.GetKey(KeyCode.D))
        {
            material.SetTextureOffset("_MainTex", new Vector2(vector.x + moveSpeed / 100, vector.y));
        }
    }


}
