using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameplayMenu : MenuBase
{
    [SerializeField] private TextMeshProUGUI scoreText;

    public TextMeshProUGUI ScoreText
    {
        get => scoreText;
        set => scoreText = value;
    }
    
}
