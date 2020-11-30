using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameplayMenu : MenuBase
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI linesText;

    public TextMeshProUGUI ScoreText
    {
        get => scoreText;
        set => scoreText = value;
    }

    public TextMeshProUGUI LinesText
    {
        get => linesText;
        set => linesText = value;
    }
}
