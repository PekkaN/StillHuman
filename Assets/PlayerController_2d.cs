using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController_2d : MonoBehaviour { 

    Animator animator;
    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;

  
    private float runMultiplier = 2;
    private float defSpeed = 3;

    private float moveSpeed = 3;

    private float defJump = 5;

     bool isGrounded;
     bool canMove;
     bool hanging;
     bool canLedgeGrab;

     public bool isCrouching;

     public bool faceRight;

// Ground checks set
    [SerializeField]
    Transform groundCheckC;
      [SerializeField]
    Transform groundCheckL;
      [SerializeField]
    Transform groundCheckR;

          [SerializeField]
    Transform grabCheckL;
        [SerializeField]
    Transform grabCheckR;

              [SerializeField]
    Transform grabCheckLnowall;
        [SerializeField]
    Transform grabCheckRnowall;


            

    // Start is called before the first frame update
    void Start() {

        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();


            
    }


    private void FixedUpdate() {

// Grounded check
        if((Physics2D.Linecast(transform.position, groundCheckC.position, 1<< LayerMask.NameToLayer("Ground"))) || 
        (Physics2D.Linecast(transform.position, groundCheckL.position, 1<< LayerMask.NameToLayer("Ground"))) ||
        (Physics2D.Linecast(transform.position, groundCheckR.position, 1<< LayerMask.NameToLayer("Ground"))))    
        {
            isGrounded = true;
            canLedgeGrab = false;
           // Debug.Log("maasa");
        } else {
            isGrounded = false;
        }
    

// Movement
        if(Input.GetKey("d") && canMove)
        {
            rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);
             if (isGrounded)
            animator.Play("Anim_Player_run");
            spriteRenderer.flipX = false;
            faceRight = false;
       
        }
        else if (Input.GetKey("a")  && canMove)
        {
            rb2d.velocity = new Vector2(moveSpeed*-1, rb2d.velocity.y);
             if (isGrounded)
            animator.Play("Anim_Player_run");
            spriteRenderer.flipX = true;
            faceRight = true;
        }

        else{
            if ((isGrounded) && !isCrouching)
            animator.Play("Anim_Player_idle");
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }

        if(Input.GetKey("space") && isGrounded)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, 5);
            animator.Play("Anim_Player_jump");
        }

// run
        if(Input.GetKey("r"))
        {
            moveSpeed = defSpeed*runMultiplier;
        } else  {
            moveSpeed = defSpeed;
        }
// crouch
   if (Input.GetKey("s")&& isGrounded){
      animator.Play("Anim_Player_crouch");
      //Debug.Log ("jej");
        isCrouching = true;
        canMove = false;

    } else {
        isCrouching = false;
         canMove = true;
    }

    //Ledge grab


    if ((!faceRight) &&
        (Physics2D.Linecast(transform.position, grabCheckR.position, 1<< LayerMask.NameToLayer("Ground"))) ){// ||
        //(Physics2D.Linecast(transform.position, grabCheckL.position, 1<< LayerMask.NameToLayer("Ground")))){
            animator.Play("Anim_Player_grab");
            rb2d.velocity = new Vector2(0, 0);
            canMove = false;
            hanging = true;
           // Debug.Log ("grabbbbb");


        } else {
            hanging = false;
        }
     
// up look and climb

    if ((Input.GetKey ("w")) && hanging){
        Debug.Log ("irti");

    }


    }


}
