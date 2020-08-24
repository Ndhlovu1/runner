using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPicker : MonoBehaviour
{
    private AudioSource coinPickSound;
    private float coinPoints = 5f;
    private ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
      coinPickSound = GameObject.Find("CoinPickSound").GetComponent<AudioSource>();
      scoreManager = FindObjectOfType<ScoreManager>();

    }

    //Collect Coin!!!!!
    void OnTriggerEnter2D(Collider2D other) {
      //Call ur player GO by actual name
      if(other.gameObject.name == "Player"){
        //The player has collected the coin, hence we'l deactivate the coin
        gameObject.SetActive(false);

          if(coinPickSound.isPlaying){
            coinPickSound.Stop();
          }

          coinPickSound.Play();
          //increase score wen coin picked
          scoreManager.score += coinPoints;


      }
    }

}
