using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;
using UnityEngine.UI;
public class Shot : MonoBehaviour
{
    public float launchSpeed = 10.0f;
    Rigidbody2D rb;
    Manager manager;
    Gun gun;
    int bullet_damage;

    // Start is called before the first frame update
    void Start()
    {
        gun = FindObjectOfType<Gun>();
         rb = this.GetComponent<Rigidbody2D>();
        manager = FindObjectOfType<Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        bullet_damage = (int)(manager.Get_cost(50, 10, 1.07f, gun.Gun_LV)) / (5 / 2);//0.4;
        rb.AddForce(transform.up * launchSpeed, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
            collision.GetComponent<Enemy>().Mob_Hp = collision.GetComponent<Enemy>().Mob_Hp - bullet_damage;
            if(collision.GetComponent<Enemy>().Mob_Hp <= 0)
            {
                Destroy(collision.gameObject);
                Spawn_Manager.Mob_Count--;
                manager.GetComponent<Manager>().Money();
            }
        }
    }

    void OnBecameInvisible()//화면밖으로 나가면 호출되는 함수
    {
        Destroy(this.gameObject);// 자기 자신을 지웁니다.
    }
}
