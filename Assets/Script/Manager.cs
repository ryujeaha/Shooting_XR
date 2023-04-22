using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public Text money_txt;
    public Text Stage_txt;

    public int i;

    public BigInteger money = 0;
    public int stage_Level = 1;
    public int Enemy_Count = 0;

    public static int Gift;
    GameData game;


    void Start()
    {
        //Debug.Log("Start");
        game = FindObjectOfType<GameData>();
        game.LoadData();
        Stage_txt.text = "Stage" + stage_Level.ToString();
        money_txt.text = "ÇöÀç µ· :" + MoneyUp(money);
    }

    // Update is called once per frame
    void Update()
    {
        Gift = (int)money;
        money_txt.text = "ÇöÀç µ· :" + MoneyUp(money);
        if (Enemy_Count == 10)
        {
            stage_Level++;
            Stage_txt.text = "Stage" + stage_Level.ToString();
            game.SaveData();
            Enemy_Count = 0;
        }
    }

    public BigInteger Get_cost(int b,int k,float r,int n)
    {
        BigInteger cost;
        cost = (BigInteger)(b * ((Mathf.Pow(r, k) - Mathf.Pow(r, k + n)) / (1 - r)));
        //Debug.Log(string.Format("b: {0}, k : {1}, r:{2}, n:{3}, total : {4}", b, k, r, n, cost));
        return cost;
    }

    public void Money()
    {
        money += Get_cost(10,10,1.06f,stage_Level);
        money_txt.text = "ÇöÀç µ· :" + MoneyUp(money);
        Enemy_Count++;
    }

    public string MoneyUp(BigInteger _money)
    {
        string value = _money.ToString();
        if (value.Trim().Length <= 3)
        {
            value = _money + "¿ø";
        }
        else if (value.Trim().Length > 3 && value.Trim().Length <= 6)
        {
            value = (money / 1000) + "K";
        }
        else if (value.Trim().Length > 6 && value.Trim().Length <= 9)
        {
            value = (money / 1000000) + "M";
        }
        else if (value.Trim().Length > 9 && value.Trim().Length <= 12)
        {
            value = (money / 1000000000) + "B";
        }
        else if (value.Trim().Length > 12 && value.Trim().Length <= 15)
        {
            value = (money / 1000000000000) + "T";
        }
        else if (value.Trim().Length > 15)
        {
            value = value.Substring(0, 1) + "." + value.Substring(1, 2) + "E" + (value.Length - 1);
        }
        return value;
    }
}
