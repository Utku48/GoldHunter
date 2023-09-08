using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI money_text;
    public TextMeshProUGUI bomb_text;

    public static float money;
    public static float bomb_Count;
    private void Update()
    {
        money_text.text = "Gold: " + money;
        bomb_text.text = bomb_Count.ToString();
    }
}
