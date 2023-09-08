using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{

    public void On_Click_Explode()
    {
        if (ScoreManager.bomb_Count > 0)
        {
            Destroy(HookManager.hold_Obj);
            HookMovement.u.move_speed = 3f;
            ScoreManager.bomb_Count--;
        }

    }

    public void On_click_Buy()
    {
        if (ScoreManager.money >= 10)
        {
            ScoreManager.bomb_Count++;
            ScoreManager.money -= 10;
        }
    }
}
