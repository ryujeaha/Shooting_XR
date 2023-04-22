using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Spawn_Manager : MonoBehaviour
{
    public GameObject Enemy;//받을 적 프리펩변수
    Manager Manager;
    public static int Mob_Count;
    public bool Mob_Max;
    // Start is called before the first frame update
    void Start()
    {
       Manager = FindObjectOfType<Manager>();
       InvokeRepeating("Spawn_Enemy", 1f,3);//만든 함수를 시작할고 1초후 2초마다 반복 
    }

    void Spawn_Enemy()//적 스폰 함수.
    {
        if (!Mob_Max)
        {
            float randomX = Random.Range(-8.3f, 8.3f);//함수 호출마다 위치 랜덤으로 지정
            float Enemy_Y = 4.4f;
            GameObject enemy = (GameObject)Instantiate(Enemy, new Vector2(randomX, Enemy_Y), Quaternion.identity);
            //게임 오브젝트 임시변수에 받은 에너미를 넣어주고 들어간 에너미를 지정한 위치에 생성한다.(X값은 랜덤)
            enemy.GetComponent<Enemy>().SpawnRan();
            enemy.GetComponent<Enemy>().Mob_Hp = Manager.Gift;
            Mob_Count++;
        }
    }
    private void Update()
    {
        if(Mob_Count >= 8)
        {
            Mob_Max = true;
        }
        else
        {
            Mob_Max = false;
        }
    }

}
