using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float Movespeed;
    public int Hp_Count = 0;
    Manager manager;
    GameData game;
    private void Start()
    {
        Hp_Count = 3;
        manager = FindObjectOfType<Manager>();
        game = FindObjectOfType<GameData>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveControl();
        if(Hp_Count <= 0)
        {
            Dead();
        }
    }
    void Dead()
    {
        Debug.Log("죽음");
        Destroy(this.gameObject);
        if (manager.stage_Level - 10 > 0)
        {
            manager.stage_Level = -10;
        }
        else
        {
            manager.stage_Level = 1;
        }
        game.SaveData();
        SceneManager.LoadScene("Game");
    }
    void MoveControl()
    {
        float dirX = Input.GetAxisRaw("Horizontal") * Time.deltaTime * Movespeed;
        this.gameObject.transform.Translate(dirX, 0, 0);//받은 값에다가 속도와 시간을 곱한만큼 이동시켜준다
    }
}
