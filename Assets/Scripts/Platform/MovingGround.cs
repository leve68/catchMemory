using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingGround : MonoBehaviour
{
    private Vector2 startposition;
    public float speed;
    public float moveX;
    public float moveY;
    // Start is called before the first frame update
    void Start()
    {
        startposition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 endpostion = startposition;
        endpostion.x += moveX * Mathf.Sin(Time.time * speed);
        endpostion.y += moveY * Mathf.Sin(Time.time * speed);
        transform.position = endpostion;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.transform.CompareTag("Player"))
            collision.transform.SetParent(transform);
    }
    private void OnCollisionExit2D(Collision2D collision) {
        if(collision.transform.CompareTag("Player"))
            collision.transform.SetParent(null);
    }
}
