using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] Text ScoreText;
    [SerializeField] Text GameOverScoreText;
    private int totalScore;
    public GameObject gameOverPanel;
    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        ScoreText.text = "Score: 0";
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    public void AddScore(int m_CoinValue)
    {
        totalScore += m_CoinValue;
        ScoreText.text = "Score: " + totalScore;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver)
        {
            gameOverPanel.SetActive(true);
            GameOverScoreText.text = ScoreText.text;
        }
    }
}
