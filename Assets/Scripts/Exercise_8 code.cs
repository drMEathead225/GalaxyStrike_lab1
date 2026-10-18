using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    int score = 0;

    public static object Instance { get; internal set; }

    public void AddScore(int amount)
    {
        score += amount;
        string v= "Score: " + score;
        scoreText.text = v;
    }
}