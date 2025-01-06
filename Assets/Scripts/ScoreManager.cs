using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int score { get => _score; set => _score = value; }
    private int _score;
    private TextMeshProUGUI scoreTextUI;

    private void Awake()
    {
        instance = this;
        scoreTextUI = GameObject.Find("ScoreTextUI").GetComponent<TextMeshProUGUI>(); //Buscamos el GO ScoreTextUI y obtenemos el Componente TextMeshProUGUI
    }

    public void AddScore() //Es void porque no devuelve nada
    {
        score++;
        AddScoreUI();
    }

    private void AddScoreUI()
    {
        scoreTextUI.text = score.ToString();
    }
}
