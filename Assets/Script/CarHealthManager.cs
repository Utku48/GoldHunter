using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarHealthManager : MonoBehaviour
{
    public Image healthBar;
    public float healthAmount = 1000f;


    private void Update()
    {
        if (healthAmount <= 0)
        {
            Debug.Log("Car Died");
        }
    }
    public void TakeDamage(float damage)
    {
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / 100;
    }


}
