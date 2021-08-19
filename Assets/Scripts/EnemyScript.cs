using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Transform playerTrans;
    float enemySpeed = 5.0f;

    
    void Awake()
    {
        playerTrans = GameObject.Find("Player").GetComponent<Transform>();
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(playerTrans.position);
        transform.Translate(0, 0, enemySpeed * Time.deltaTime);
    }
}
