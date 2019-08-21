using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBarScript : MonoBehaviour
{   
    public Image _hpbar;    
    public float maxHealth = 100;
    public float health;
    private int mCurrentValue;
    
    void Start()
    {
        
        health = maxHealth;
        
    }

    
    void Update()
    {
       
    }
    public void Damage(float damage)
    {
        health -= damage;
        _hpbar.fillAmount = (health / maxHealth);
    }
}
