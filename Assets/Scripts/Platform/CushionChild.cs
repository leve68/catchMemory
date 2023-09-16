using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CushionChild : Cushion
{
    private SpriteRenderer cushionSprite;
    private SpriteRenderer parentSprite;
    // Start is called before the first frame update
    void Start()
    {
        parentSprite = transform.parent.GetComponent<SpriteRenderer>();
        cushionSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {  
        if (parentSprite.enabled)
        {
            cushionSprite.enabled = true;
        }
        else
        {
            cushionSprite.enabled = false;
        }
    }
}
