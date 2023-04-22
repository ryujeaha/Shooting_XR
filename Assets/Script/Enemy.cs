using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy : MonoBehaviour
{
    public Transform target;
    public static int money = 0;
    public int Mob_Hp;
    public float speed = 0.01f;
    int speedran = 0;
    Player player;
    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        Enemy_Move();
    }
    void Enemy_Move()
    {
        target = GameObject.Find("Player").transform; //Player 위치받기
        if(speedran == 6)
        {
            this.speed = 0.014f;
        }
        else
        {
            this.speed = 0.009f;
        }
        transform.position = Vector2.MoveTowards(transform.position, target.position, this.speed );
    }
   public void SpawnRan()
    {
        speedran = Random.Range(1,7);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            player.Hp_Count--;
            Spawn_Manager.Mob_Count--;
            Destroy(this.gameObject);
        }
    }
}
