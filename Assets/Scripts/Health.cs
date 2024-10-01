using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Health : MonoBehaviour
{
    public float hp = 10;
    public IHealthListener healthListener;
    public float invincibleTime;

    public Image hpGauge;

    float maxHP;
    float lastAttackedTime;

    // Start is called before the first frame update
    void Start()
    {
        maxHP = hp;
       healthListener = GetComponent<Health.IHealthListener>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(float damage)
    {
        if (hp > 0 && lastAttackedTime + invincibleTime < Time.time)
        {
            hp -= damage;
            if (hpGauge != null)
            {
                hpGauge.fillAmount = hp / maxHP;
            }
            lastAttackedTime = Time.time;
            if (hp <= 0)
            {
                if(healthListener != null)
                {
                    healthListener.Die();
                }
            }
        }
    }

    public interface IHealthListener 
    {
        void Die();
    }
}
