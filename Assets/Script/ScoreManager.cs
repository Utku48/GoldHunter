using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI money_text;
    public TextMeshProUGUI bomb_text;
    public TextMeshProUGUI player_count_text;
    public TextMeshProUGUI year_text;
    public TextMeshProUGUI wave_text;

    public static float money;
    public static float bomb_Count;
    public static float player_Count = 1;
    public static float year = 50;
    public static float wave_value = 1;
    private void Update()
    {
        money_text.text = "Gold: " + money;
        bomb_text.text = bomb_Count.ToString();
        year_text.text = "Year: " + year.ToString();
        wave_text.text = "Wave: " + wave_value.ToString();

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
