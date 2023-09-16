using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleItem : MonoBehaviour
{
    private Vector2 startposition;
    public float moveY;
    public float speed;
    private LIfe _life;
    // Start is called before the first frame update
    void Start()
    {
        startposition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        Vector2 endpostion = startposition;
        endpostion.y += moveY * Mathf.Sin(Time.time * speed);
        transform.position = endpostion;
        */
    }

    //player life 증가
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player") {
            GameObject.FindWithTag("Player").GetComponent<LIfe>().LifeIn();
            GameObject.FindWithTag("UI").GetComponent<PlayerControl>().LifeChange();
        }
    }
}
