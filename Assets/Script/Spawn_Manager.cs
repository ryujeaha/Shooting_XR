using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Spawn_Manager : MonoBehaviour
{
    public GameObject Enemy;//���� �� �����麯��
    Manager Manager;
    public static int Mob_Count;
    public bool Mob_Max;
    // Start is called before the first frame update
    void Start()
    {
       Manager = FindObjectOfType<Manager>();
       InvokeRepeating("Spawn_Enemy", 1f,3);//���� �Լ��� �����Ұ� 1���� 2�ʸ��� �ݺ� 
    }

    void Spawn_Enemy()//�� ���� �Լ�.
    {
        if (!Mob_Max)
        {
            float randomX = Random.Range(-8.3f, 8.3f);//�Լ� ȣ�⸶�� ��ġ �������� ����
            float Enemy_Y = 4.4f;
            GameObject enemy = (GameObject)Instantiate(Enemy, new Vector2(randomX, Enemy_Y), Quaternion.identity);
            //���� ������Ʈ �ӽú����� ���� ���ʹ̸� �־��ְ� �� ���ʹ̸� ������ ��ġ�� �����Ѵ�.(X���� ����)
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
