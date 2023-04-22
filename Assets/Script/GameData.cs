using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; // Serializable
using System.IO;//File Input Ouput
using System.Numerics;

public class PlayerData
{
    public int clickerLevel;
    public int stageLevrel;
    public string gold;//Big Integer ������ ��Ʈ������ ����

    public void SetData(Manager m,Gun g)
    {
        m.stage_Level = stageLevrel;
        m.money = BigInteger.Parse(gold);
        g.Gun_LV = clickerLevel;
    }
}
public class GameData : MonoBehaviour
{
   public Gun gun;
   public Manager manager;
    BigInteger gold;
    string true_str;
    void Awake()
    {
      gun =  FindObjectOfType<Gun>();
      manager = FindObjectOfType<Manager>();
    }

  public void SaveData()
    {
        PlayerData mydata = new PlayerData();
        mydata.clickerLevel = gun.Gun_LV;
        mydata.stageLevrel = manager.stage_Level;
        gold = manager.money;
        mydata.gold = gold.ToString();

        string str = JsonUtility.ToJson(mydata);//��Ʈ�����ٰ� ���̽����� ��ȯ�� ���̵���Ÿ ����

        Debug.Log(str);

        File.WriteAllText(Application.persistentDataPath + "/PlayerData.json", JsonUtility.ToJson(mydata));

        true_str = str;
    }

    public void LoadData()//str�� ����(�ܺο���)
    {

        string jsonData = File.ReadAllText(Application.persistentDataPath + "/PlayerData.json");

        PlayerData data2 = JsonUtility.FromJson<PlayerData>(jsonData);//������ �ε�
        data2.SetData(manager,gun);
    }    
}

