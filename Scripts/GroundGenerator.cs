using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{

    public Transform groundPoint;
    public Transform MinHeightPoint;
    public Transform MaxHeightPoint;

    private  float minY;
    private float maxY;

    public float minGap;
    public float maxGap;

    public ObjectPooler[] groundPoolers;
    private float[] groundWidths;

    private CoinsGenerator coinGenerator;

    // Start is called before the first frame update
    void Start()
    {

      minY = MinHeightPoint.position.y;
      maxY = MaxHeightPoint.position.y;

      groundWidths = new float[groundPoolers.Length];
      for(int i = 0; i<groundPoolers.Length; i++){
        groundWidths[i] = groundPoolers[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
      }

      //Calling the coin Generator to multiply the CoinsGenerator
      coinGenerator = FindObjectOfType<CoinsGenerator>();

    }

    // Update is called once per frame
    void Update()
    {
          float gap = Random.Range(minGap, maxGap);
          float height = Random.Range(minY, maxY);

          if (transform.position.x < groundPoint.position.x){
            int random = Random.Range(0, groundPoolers.Length);
            float distance = groundWidths[random] /2 ;

          transform.position = new Vector3(
          transform.position.x + distance + gap,
          height, transform.position.z);

          GameObject ground = groundPoolers[random].GetPooledGameObject();
          ground.transform.position = transform.position;
          ground.SetActive(true);
          //Generate the coins
          coinGenerator.SpawnCoins(
            transform.position,
            //Use the array to pass the full proper width of the ground in iorder to be able to generate multiple CoinsGenerator
            groundWidths[random]
          );


          //Regenerate the grounds aftr they've been added.
          transform.position = new Vector3(
          transform.position.x + distance,
          transform.position.y, transform.position.z);

      }



        }
}
