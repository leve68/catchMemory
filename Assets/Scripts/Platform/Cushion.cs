using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cushion : MonoBehaviour
{
    public bool isActive = false;
    public BoxCollider2D cushionCollider;
    private SpriteRenderer cushionSprite;
    // Start is called before the first frame update
    void Start()
    {
        cushionCollider = GetComponent<BoxCollider2D>();
        cushionSprite = GetComponent<SpriteRenderer>();
        cushionCollider.enabled = false;
        cushionSprite.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.childCount < 3 && cushionCollider.enabled == false)
        {
            cushionCollider.enabled = true;
            cushionSprite.enabled = true;
            GameObject.FindWithTag("Player").GetComponent<Character>().SetNoBlinkImmune(3f);
            GameObject.FindWithTag("MainCamera").GetComponent<CharacterCamera>().target = this.gameObject;
            Invoke("Delay", 2f);
        }

    }

    private void Delay()
    {
        GameObject.FindWithTag("MainCamera").GetComponent<CharacterCamera>().target = GameObject.FindWithTag("Player");
    }
}
