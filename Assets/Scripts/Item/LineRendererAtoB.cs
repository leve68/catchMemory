using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class LineRendererAtoB : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private SpriteRenderer sprite;

    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        sprite= GetComponent<SpriteRenderer>();
        lineRenderer.positionCount = 3;
        lineRenderer.enabled = false;
        sprite.enabled = false;
    }

    public void Play(Vector2 from, Vector2 to)
    {   
        transform.position = from + new Vector2(1f,1f);
        lineRenderer.enabled = true;
        from.x += 1; from.y += 1;
        Vector2 startP = new Vector2(from.x + 10, from.y + 10);
        lineRenderer.SetPosition(0, startP);
        lineRenderer.SetPosition(1, from);
        lineRenderer.SetPosition(2, to);
        sprite.enabled = true;
    }

    public void Stop()
    {
        lineRenderer.enabled = false;
        sprite.enabled = false;
    }
}
