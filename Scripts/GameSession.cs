using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameSession : MonoBehaviour
{
    [SerializeField] int playerlives = 10;
    [SerializeField] int Score;
    [SerializeField] Text LivesText;
    [SerializeField] Text ScoreText;
    private void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        LivesText.text = playerlives.ToString();
        ScoreText.text = Score.ToString();
    }

    public void AddToScore(int pointstoadd)
    {
        Score += pointstoadd;
        ScoreText.text = Score.ToString();
    }
    public void PlayerLostLife()
    {
        if(playerlives > 1)
        {
            playerlives -= 1;
            LivesText.text = playerlives.ToString();
            var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
        }
        else
        {
            SceneManager.LoadScene(0);
            Destroy(gameObject);
        }
    }
}
