using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public GameObject secret_Button;

    public GameObject panel;
    private bool isPanelOpen = false;
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

    public void PanelController()
    {
        isPanelOpen = !isPanelOpen;
        panel.SetActive(isPanelOpen);

        if (panel.activeSelf)
        {
            secret_Button.SetActive(false);
        }
        else
        {
            secret_Button.SetActive(true);
        }
    }

    public void Player_Count()
    {
        if (ScoreManager.money >= 10)
        {
            ScoreManager.player_Count++;
            ScoreManager.money -= 10;

        }

    }
}
