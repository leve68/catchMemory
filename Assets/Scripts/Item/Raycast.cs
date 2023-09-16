using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    [SerializeField] private LineRendererAtoB visualizerLine;

    [SerializeField] private List<GameObject> findList;
    [SerializeField] private List<GameObject> inCameraMonsterList;
    [SerializeField] private Camera cam;
    [SerializeField] public GameObject closestMonster;
    [SerializeField] private GameObject player;
    [SerializeField] private Vector2 playerPosition;
    [SerializeField] public bool isActive=false;
    [SerializeField] private GameObject[] Monsters;
    [SerializeField] private GameObject[] BlackSlimes;
    [SerializeField] private GameObject[] HedgeHog;
    private AudioSource audioSource;

    public void Start()
    {
        visualizerLine = GetComponentInChildren<LineRendererAtoB>();
        cam = UnityEngine.Camera.main;
        playerPosition = GameObject.FindWithTag("Player").transform.position;
        FindClosestMonster();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            player = GameObject.FindWithTag("Player");
            Monsters = GameObject.FindGameObjectsWithTag("Monster");
            BlackSlimes = GameObject.FindGameObjectsWithTag("BlackSlime");
            HedgeHog = GameObject.FindGameObjectsWithTag("BlackSlime");
            findList = new List<GameObject>();
            for (int i = 1; i < Monsters.Length; i++)
            {
                findList.Add(Monsters[i]);
            }
            for (int i = 1; i < BlackSlimes.Length; i++)
            {
                findList.Add(BlackSlimes[i]);
            }
            for (int i = 1; i < HedgeHog.Length; i++)
            {
                findList.Add(HedgeHog[i]);
            }
            audioSource.Play();
            FindClosestMonster();
            isActive= false;
        }

        if (closestMonster!= null)
        {
            playerPosition = player.transform.position; 
            Vector2 direction = ((Vector2)closestMonster.transform.position - playerPosition).normalized;

            Debug.DrawRay(playerPosition, direction, new Color(0, 1, 0));

            visualizerLine.Play(playerPosition, closestMonster.transform.position);
            if (closestMonster.transform.CompareTag("BlackSlime"))
            {
                closestMonster.GetComponent<RedAndBlackSlime>().RayHit();
            }
            Invoke("Delay", 1f);
        }
            
    }

    //���尡��� ���� ã��
    private void FindClosestMonster()
    {
        inCameraMonsterList = new List<GameObject>();
        for (int i = 0; i < findList.Count; i++)
        {
            //ȭ��ȿ� ������ ���͸� inCameraMonsterList�� ����
            Vector2 viewPos = cam.WorldToViewportPoint(findList[i].transform.position);
            if (viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1 )
            {
                Debug.Log(i);
                inCameraMonsterList.Add(findList[i]);
            }
        }

        //�÷��̾�� ���� ����� ���� ã��
        if (inCameraMonsterList.Count < 1)
        {
            Debug.Log("���;���");
            closestMonster= null;
            //visualizerLine.Stop();
        }
        else
        {
            closestMonster = inCameraMonsterList[0];
            for (int i = 1; i < inCameraMonsterList.Count; i++)
            {
                if (Mathf.Abs(closestMonster.transform.position.x - playerPosition.x) > Mathf.Abs(inCameraMonsterList[i].transform.position.x - playerPosition.x))
                {
                    closestMonster = inCameraMonsterList[i];
                }
            }
            inCameraMonsterList= null;//ã�� ����Ʈ�� �ʱ�ȭ ����� ����� ����Ʈ�� ��� ã������
        }
        findList = null;
    }

    private void Delay()
    {
        Debug.Log("1������");
        visualizerLine.Stop();
        closestMonster = null;
    }
}
