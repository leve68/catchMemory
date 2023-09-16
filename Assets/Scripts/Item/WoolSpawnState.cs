using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoolSpawnState : MonoBehaviour
{
    private Vector2 startposition;
    [SerializeField] private float moveY;
    [SerializeField] private float speed;
    [SerializeField] private AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        startposition = transform.position;
        audio= GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 endpostion = startposition;
        endpostion.y += moveY * Mathf.Sin(Time.time * speed);
        transform.position = endpostion;
    }

    //아이템획득 효과음출력, 파괴지연해야 출력함
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player") 
        {
            this.GetComponent<BoxCollider2D>().enabled = false;
            this.GetComponent<SpriteRenderer>().enabled = false;
            Destroy(this.gameObject, 1f);
        }
    }

}
