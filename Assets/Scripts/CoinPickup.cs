using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] AudioClip myClip;
    public int playerScore = 100;
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            FindObjectOfType<GameSession>().AddToScore(playerScore);
            AudioSource.PlayClipAtPoint(myClip, Camera.main.transform.position);
            Destroy(gameObject);
        }
    }
}
