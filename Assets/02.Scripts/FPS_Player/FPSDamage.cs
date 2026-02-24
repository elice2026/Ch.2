using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FPSDamage : MonoBehaviour
{
    private int hp = 0;
    private int hpInit = 100;
    public Image hpBar;
    void Start()
    {
        hp = hpInit;
        hpBar.color = Color.green;
    }
    private void OnTriggerEnter(Collider other) //isTrigger check
    {
        if(other.gameObject.tag =="PUNCH")
        {
            hp -= 5;
            hp = Mathf.Clamp(hp, 0, 100);
            hpBar.fillAmount = (float)hp / (float)hpInit;
            HpBarColor();
            if (hp <= 0)
            {
                PlayerDie();
            }
        }

    }

    private void HpBarColor()
    {
        if (hpBar.fillAmount <= 0.3f)
            hpBar.color = Color.red;
        else if (hpBar.fillAmount <= 0.5f)
            hpBar.color = Color.yellow;
    }

    void PlayerDie()
    {
        Debug.Log($"주인공 사망!"); //콘솔창에 주인공 사망이라고 기록된다.
    }
}
