using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Gun : MonoBehaviour
{
    public Text Speed;

    public int Gun_LV = 1;
    public float Atk_Speed;

    public Text money_txt;
    public Text Stage_txt;

    Transform Player_trans;
    public GameObject Shot;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Spawn_Shot");
    }

    // Update is called once per frame
    void Update()
    {
        Player_trans = GameObject.Find("Player").transform; //Player 위치받기
        Atk_Speed =  Mathf.Sqrt(Gun_LV) / Gun_LV ;
        Speed.text = Atk_Speed.ToString();
    }

   IEnumerator Spawn_Shot()
    {
      yield return new WaitForSeconds(Atk_Speed);
        GameObject shot = (GameObject)Instantiate(Shot, new Vector2(Player_trans.position.x, Player_trans.position.y), Quaternion.identity);
        StartCoroutine("Spawn_Shot");
    }
}
