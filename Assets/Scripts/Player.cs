using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

   
  

    private Animation thisAnimation;

    private GameManager yes;

    private int jumpSpeed = 4;
    private int score;

    public Rigidbody rb;

    public float jumpHeight = 7f;


    void Start()
    {
        

        yes = FindObjectOfType<GameManager>();
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            thisAnimation.Play();

            rb.velocity = Vector3.up * jumpSpeed;


        }






           
    }

  

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Score" )
        {
            yes.UpdateScore(1);
        }



    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Trap")
        {

            yes.GameOver();
        }
    }
}
