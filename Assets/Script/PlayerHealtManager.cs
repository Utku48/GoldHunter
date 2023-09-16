using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealtManager : MonoBehaviour
{
    public Image healthBar;
    public float healthAmount = 1000f;

    public static bool player_alive = true;


    private void Update()
    {
        Debug.Log(player_alive);

        if (healthAmount <= 0)
        {
            player_alive = false;
        }

        if (PlayerWallManager.inPlayerWall)
        {
            TakeDamage(.1f);
        }

    }
    public void TakeDamage(float damage)
    {
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / 100;

    }

}
