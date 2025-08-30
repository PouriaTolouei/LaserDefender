using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{

    Health health;
    ScoreKeeper scoreKeeper;
    Slider healthSlider;
    TextMeshProUGUI score;

    void Start()
    {
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        scoreKeeper = FindAnyObjectByType<ScoreKeeper>();

        healthSlider = GetComponentInChildren<Slider>();
        score = GetComponentInChildren<TextMeshProUGUI>();
        
        healthSlider.maxValue = health.GetHealth();
    }

    void Update()
    {
        UpdateHealthSlider();
        UpdateScore();
    }

    void UpdateHealthSlider()
    {
        healthSlider.value = health.GetHealth();
    }

    void UpdateScore()
    {
        score.text = scoreKeeper.GetScore().ToString("000000000");
    }
}
