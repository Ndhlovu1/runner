using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
Create a Quad in the Camera GO,
Enlarge it over the Camera
increase the z value in the transform to more than 1 preferably 10 to add it to the back
then
Create this Scrolling background, attach this to the Quad u are working wth to make a scrolling bg
Then Initialize the values from the Front End of the Script(In this case BgSpeed) as a Decimal
Then ADD THE Quad to the background slot


**/

public class Scrollingbg : MonoBehaviour
{

  public Renderer bg;
  public  float bgSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      bg.material.mainTextureOffset += new Vector2(bgSpeed * Time.deltaTime, 0f);

    }
}
