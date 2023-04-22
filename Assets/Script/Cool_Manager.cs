using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Cool_Manager : MonoBehaviour
{
    public Image[] img_skill;
    void Update()
    {
        Q_Skill();
        W_Skill();
        E_Skill();
        R_Skill();
    }

    public void Q_Skill()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(Q_Cooltime(3f));
        }
    }
    public void W_Skill()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            StartCoroutine(W_Cooltime(5f));
        }
    }
    public void E_Skill()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(E_Cooltime(7f));
        }
    }
    public void R_Skill()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(R_Cooltime(10f));
        }
    }
    IEnumerator Q_Cooltime(float Q_cool)
    {
        while(Q_cool > 1.0f)
        {
            Q_cool -= Time.deltaTime;
            this.img_skill[0].fillAmount = (1.0f / Q_cool);
            yield return new WaitForFixedUpdate();//정밀한 시간계산을 하겠다는 의미
        }
    }

    IEnumerator W_Cooltime(float cool)
    {
        while (cool > 1.0f)
        {
            cool -= Time.deltaTime;
            this.img_skill[1].fillAmount = (1.0f / cool);
            yield return new WaitForFixedUpdate();//정밀한 시간계산을 하겠다는 의미
        }
    }

    IEnumerator E_Cooltime(float cool)
    {
        while (cool > 1.0f)
        {
            cool -= Time.deltaTime;
            this.img_skill[2].fillAmount = (1.0f / cool);
            yield return new WaitForFixedUpdate();//정밀한 시간계산을 하겠다는 의미
        }
    }

    IEnumerator R_Cooltime(float cool)
    {
        while (cool > 1.0f)
        {
            cool -= Time.deltaTime;
            this.img_skill[3].fillAmount = (1.0f / cool);
            yield return new WaitForFixedUpdate();//정밀한 시간계산을 하겠다는 의미
        }
    }
}
