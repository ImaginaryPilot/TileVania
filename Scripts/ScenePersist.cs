using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePersist : MonoBehaviour
{
    int startingsceneindex;
    private void Awake()
    {
        int numGameSessions = FindObjectsOfType<ScenePersist>().Length;
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
        startingsceneindex = SceneManager.GetActiveScene().buildIndex;
    }
    private void Update()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if(currentSceneIndex != startingsceneindex)
        {
            Destroy(gameObject);
        }
    }
}
