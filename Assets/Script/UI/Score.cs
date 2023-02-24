using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _scoreText;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        score = PlayerSpawn._instance._playerCount;
    }

    private void Update()
    {
        score = PlayerSpawn._instance._playerCount;
        _scoreText.text = "Score : " + score.ToString();

    }
}
