using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsGenerator : MonoBehaviour
{

  public ObjectPooler coinPooler;

  public void SpawnCoins(Vector3 position, float groundWidth){

    int random = Random.Range(1,100);
    if(random < 50){
      return;
    }


    int numberOfCoins = (int) Random.Range(3f, groundWidth);
  //Generate the coins randomly can be replaced by the position.u + 2
    float y = Random.Range(2,4);
    for(int i=0; i<numberOfCoins; i++) {
      GameObject coin = coinPooler.GetPooledGameObject();

      //Remove the groundWidth/2 if u dont like the way the coins look
      coin.transform.position = new Vector3(position.x - (groundWidth/2)+ i,
      position.y + y, 0);
      //position.y + 2, 0)
    coin.SetActive(true);
  }

}

}
