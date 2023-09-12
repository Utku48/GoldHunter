using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI money_text;
    public TextMeshProUGUI bomb_text;
    public TextMeshProUGUI player_count_text;

    public static float money;
    public static float bomb_Count;
    public static float player_Count = 1;
    private void Update()
    {
        money_text.text = "Gold: " + money;
        bomb_text.text = bomb_Count.ToString();

        if (player_Count <= 6)
        {
            player_count_text.text = player_Count.ToString();
        }
        else
        {
            player_count_text.text = "Maximum Player";
        }

    }
}
