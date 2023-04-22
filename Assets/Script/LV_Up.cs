using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;

public class LV_Up : MonoBehaviour
{
    Manager manager;
    Gun gun;

    private void Start()
    {
         manager = FindObjectOfType<Manager>();
        gun = FindObjectOfType<Gun>();
    }

   public void Lv_Up()
    {
        if(manager.money >= manager.Get_cost(50,10,1.07f,gun.Gun_LV))
        {
            manager.money -= manager.Get_cost(50,10,1.07f,gun.Gun_LV);
            gun.Gun_LV++;
        }
    }
}
