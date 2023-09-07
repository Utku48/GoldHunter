using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshPro money_text;
    public int score;
    private void Update()
    {
        money_text.text = "Money: " + score;
    }
}
