using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    int points;
    // Start is called before the first frame update
    void Start()
    {
        points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Wynik: " + points.ToString();
    }
    public void AddPoints(int pointsToAdd)
    {
        points += pointsToAdd;
    }
}
