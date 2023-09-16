using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxDetectPlayer : MonoBehaviour
{
    public Collider2D playerCollider;
    private void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            playerCollider = other;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Player")
        {
            Invoke("delayNull", 1f); //delayNull을 실행시키고 1초 지연
        }
    }

    void delayNull(){
        playerCollider = null;
    }
}
