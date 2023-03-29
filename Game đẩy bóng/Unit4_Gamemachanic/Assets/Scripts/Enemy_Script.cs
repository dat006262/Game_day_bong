using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Script : MonoBehaviour
{
    public float speed = 2;
    private Rigidbody rigid_enemy;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        rigid_enemy = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 veclookplayer = player.transform.position - this.transform.position;
        rigid_enemy.AddForce((veclookplayer).normalized*speed);
        if (transform.position.y < -10)
            Destroy(gameObject);    
    }
}
