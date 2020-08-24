using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
//Get the player location
  private Player player;
//Get the Vector3 to get the position of the player, it stores x,y and z
  private Vector3 lastPosition;
  //Define the distance for the camera to move
  private float distance;

    // Start is called before the first frame update
    void Start()
    {

      //Initialize player
      player = FindObjectOfType<Player>();
      lastPosition = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
      //Get the player direction with the x direction only
      distance = player.transform.position.x - lastPosition.x;
      //Setting new Camera lastPosition
      transform.position = new Vector3(transform.position.x + distance,
        transform.position.y,transform.position.z);
      lastPosition = player.transform.position;



    }
}
