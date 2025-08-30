using TMPro;
using UnityEngine;

public class UIGameOver : MonoBehaviour
{

    ScoreKeeper scoreKeeper;
    TextMeshProUGUI finalScore;


    void Start()
    {
        scoreKeeper = FindAnyObjectByType<ScoreKeeper>();
        finalScore = GameObject.FindGameObjectWithTag("FinalScore").GetComponent<TextMeshProUGUI>();
        finalScore.text = scoreKeeper.GetScore().ToString();
  
    }

}
