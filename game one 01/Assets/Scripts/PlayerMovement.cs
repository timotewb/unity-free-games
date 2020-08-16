using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] private  float jumpForce = 20f;
    [SerializeField] private  float jumpStopForce = .75f;
    [SerializeField] private  float jumpTime = .13f;
    [SerializeField] private LayerMask platformLayerMask;
    private float moveLR;
    private Rigidbody2D rb2D;
    private CapsuleCollider2D cc2D;
    private bool isJumping;
    private bool isFalling;
    private float jumpTimerCounter;
    // Start is called before the first frame update
    void Start(){
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        cc2D = gameObject.GetComponent<CapsuleCollider2D>();
    }

    void FixedUpdate(){
        moveLR = Input.GetAxisRaw("Horizontal");
        rb2D.velocity = new Vector2(moveLR * moveSpeed, rb2D.velocity.y);
    }

    void Update() {
        // player facing direction
        if (moveLR > 0) {
            // move right
            transform.eulerAngles = new Vector3(0,180,0);
        } else if (moveLR < 0) {
            // move left
            transform.eulerAngles = new Vector3(0,0,0);
        }

        // player jump
        if(IsGrounded() && Input.GetKeyDown(KeyCode.Space)) {
            // if on ground and user wants to jump
            rb2D.velocity = Vector2.up * jumpForce;
            //rb2D.gravityScale = 0;
            jumpTimerCounter = jumpTime;
            isJumping = true;
            isFalling = false;
        } else if (Input.GetKeyUp(KeyCode.Space) && isFalling == false) {
            // if user lets go of jump
            //rb2D.gravityScale = 4;
            rb2D.velocity = Vector2.down * jumpStopForce;
            isJumping = false;
            // 1st time user lifts space, player will start falling
            isFalling = true;
        }

        if (isJumping == true && Input.GetKey(KeyCode.Space) && jumpTimerCounter > 0) {
            // if user is holding jump
            if(!(jumpTimerCounter <= (jumpTime /2))){
                rb2D.velocity = Vector2.up * jumpForce;
            }
            jumpTimerCounter -= Time.deltaTime;
            //rb2D.gravityScale = 0;
        } else if(isJumping == true && Input.GetKey(KeyCode.Space) && jumpTimerCounter <= 0){
            // if user gets to max jumpTime
            //rb2D.gravityScale = 4;
            rb2D.velocity = Vector2.down * rb2D.gravityScale * jumpStopForce;
            isJumping = false;
            // 1st time user lifts space, player will start falling
            isFalling = true;
        }

        // limit fall speed
        if(rb2D.velocity.y < -jumpForce){
            rb2D.velocity = Vector2.down * jumpForce;
        }
    }

    bool IsGrounded(){
        RaycastHit2D rch2D = Physics2D.BoxCast(cc2D.bounds.center, cc2D.bounds.size, 0f, Vector2.down, .1f, platformLayerMask);
        return rch2D.collider != null;
    }
}
