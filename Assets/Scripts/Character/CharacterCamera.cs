using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCamera : MonoBehaviour
{
    [SerializeField] float x = 3;
    [SerializeField] float y = 1;
    public GameObject target;
    private Vector3 offset;

    private BoxCollider2D cameraBounds;
    private PlayerControl playerUI;

    public Vector3 desiredPosition; // ��ǥ ��ġ�� ������ ����
    public float smoothSpeed = 0.02f; // ������ ����� ������ ��

    private void Start()
    {
        Util.SetResolution();
        target = GameObject.FindWithTag("Player");
        offset = new Vector3(x, y, -10);
        cameraBounds = GameObject.FindWithTag("Bound").GetComponent<BoxCollider2D>();

        playerUI = target.GetComponent<Character>().GetUI();
    }

    private void LateUpdate()
    {
        Vector3 targetPosition = target.transform.position + offset;
        Vector3 clampedPosition = new Vector3(
            Mathf.Clamp(targetPosition.x, cameraBounds.bounds.min.x, cameraBounds.bounds.max.x),
            Mathf.Clamp(targetPosition.y, cameraBounds.bounds.min.y, cameraBounds.bounds.max.y),
            targetPosition.z
        );

        desiredPosition = Vector3.Lerp(transform.position, clampedPosition, smoothSpeed);

        transform.position = desiredPosition;

        if (playerUI.isMovingLeft == true || Input.GetKeyDown(KeyCode.A))
        {
            offset = new Vector3(-x, y, -10);
        }
        if (playerUI.isMovingRight == true || Input.GetKeyDown(KeyCode.D))
        {
            offset = new Vector3(x, y, -10);
        }
    }
}
