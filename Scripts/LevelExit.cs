using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelExit : MonoBehaviour
{
    [SerializeField] float timewaiting = 3f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(Exitlevel());
    }

    IEnumerator Exitlevel()
    {
        Time.timeScale = 0.3f;
        yield return new WaitForSecondsRealtime(timewaiting);
        Time.timeScale = 1f;
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
