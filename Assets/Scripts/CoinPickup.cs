using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] int coinscore = 100;
    [SerializeField] AudioClip coin;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<GameSession>().AddToScore(coinscore);
        AudioSource.PlayClipAtPoint(coin, Camera.main.transform.position);
        Destroy(gameObject);
    }
}
