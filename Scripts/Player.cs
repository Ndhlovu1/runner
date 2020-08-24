using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  private Animator animator;
  public LayerMask ground;
  public float jump;
  public float speed;
  private Rigidbody2D rb;
  private Collider2D playerCollider;
  //Killing Player
  public LayerMask deathGround;


public AudioSource deathSound;
public AudioSource jumpSound;

//Adding speed
  public float mileStone;
  private float mileStoneCount;
  public float speedMultiplier;

  public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();

        mileStoneCount = mileStone;
    }

    // Update is called once per frame
    void Update()
    {
      //Checking if player is dead
      bool dead = Physics2D.IsTouchingLayers(playerCollider, deathGround);
      if(dead){
          GameOver();
      }


      if(transform.position.x > mileStoneCount){
        //Increase milestone count
        mileStoneCount += mileStone;
        speed = speed * speedMultiplier;
        mileStone += mileStone * speedMultiplier;
        Debug.Log("M"+mileStone+", MC"+mileStoneCount+", MS"+speed);

      }

      //Collecting the/assigning the directions, Vector2 takes x,y respectively
      rb.velocity = new Vector2(speed, rb.velocity.y);
      bool grounded = Physics2D.IsTouchingLayers(playerCollider, ground);

      if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)){
        if(grounded){
          jumpSound.Play();
          rb.velocity = new  Vector2(rb.velocity.x, jump); }

      }
      animator.SetBool("Grounded",grounded);

    }

    void GameOver(){
      //Design a Game Over Screen First
      gameManager.GameOver();
      

    }

}
