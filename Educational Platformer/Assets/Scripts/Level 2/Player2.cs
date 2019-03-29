using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player2 : MonoBehaviour
{
    //Config
    //10
    [SerializeField] float jumpSpeed = 5f;
    //20
    [SerializeField] float runSpeed = 5f;
    //
    [SerializeField] float climbSpeed = 5f;


    public GameObject player;
    //Components
    public Rigidbody2D myRigidBody;
    public Animator myAnimator;
    public CapsuleCollider2D myBodyCollider;
    public BoxCollider2D myFeet;
    float gravityScaleAtStart;

    public bool isAlive = true;



    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        myFeet = GetComponent<BoxCollider2D>();
        gravityScaleAtStart = myRigidBody.gravityScale;
        //player.transform.Find("RadioactiveProtection").gameObject.SetActive(FindObjectOfType<GameSession>().hazmatSuitObtained);
        if (!FindObjectOfType<GameSession2>().firstSpawn)
        {

            player.transform.position = FindObjectOfType<GameSession2>().GetRespawnPoint();

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive) { return; }
        if (Time.timeScale == 0f) { return; }
        Walk();
        Die();
        Jump();
        FlipSprite();
        ClimbLadder();
    }

    private void Walk()
    {
        float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal"); // value betweem -1 and 1
        Vector2 playerVelocity = new Vector2(controlThrow * runSpeed, myRigidBody.velocity.y);
        myRigidBody.velocity = playerVelocity;

        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("Walking", playerHasHorizontalSpeed);
    }

    private void ClimbLadder()
    {
        if (!myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Ladder")))
        {
            myRigidBody.gravityScale = gravityScaleAtStart;
            myAnimator.SetBool("ClimbLadder", false);
            return;
        }
        float controlThrow = CrossPlatformInputManager.GetAxis("Vertical"); // value betweem -1 and 1
        Vector2 climbVelocity = new Vector2(myRigidBody.velocity.x, controlThrow * climbSpeed);
        myRigidBody.velocity = climbVelocity;
        myRigidBody.gravityScale = 0f;
        myAnimator.SetBool("ClimbLadder", true);

        //bool playerHasVerticalSpeed = Mathf.Abs(myRigidBody.velocity.y) > Mathf.Epsilon;
        //myAnimator.SetBool("climb",playerHasVerticalSpeed);


    }

    private void Jump()
    {
        if (!myFeet.IsTouchingLayers(LayerMask.GetMask("Ground")) && !myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Ladder")) && !myBodyCollider.IsTouchingLayers(LayerMask.GetMask("LaserObs")))
        {
            myAnimator.SetBool("Jumping", true);
            return;
        }
        if (CrossPlatformInputManager.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.UpArrow))
        {
            Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);
            myRigidBody.velocity += jumpVelocityToAdd;
        }
        if (myFeet.IsTouchingLayers(LayerMask.GetMask("Ground")) || myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Ladder")) || myBodyCollider.IsTouchingLayers(LayerMask.GetMask("LaserObs")))
        {
            myAnimator.SetBool("Jumping", false);
        }
    }

    private void Die()
    {
        if (myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemy", "Hazards")))
        {
            if (myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Hazards")) && FindObjectOfType<PreventDeath>().GetBool())
            {
                return;
            }
            myAnimator.SetTrigger("Dying");
            Vector2 playerVelocity = new Vector2(0, 0);
            myRigidBody.velocity = playerVelocity;
            isAlive = false;
            FindObjectOfType<GameSession2>().ProcessPlayerDeath();
        }
    }

    private void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;

        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x), 1f);
        }
    }
}
