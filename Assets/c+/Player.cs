using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public Transform groundChick;
    public LayerMask ground;
    Animator anim;

    [Header("移動參數")]
    public float speed;
    public float jumpForce;

    [Header("狀態")]
    public bool isGround;
    public bool isJump;
    bool jumpPressed;

    [Header("UI")]
    public Text cherryText;
    public int cherryCount;

    float horizontalMove;
 


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && isGround)
            jumpPressed = true;
    }
    void FixedUpdate()
    {
        isGround = Physics2D.OverlapCircle(groundChick.position, 0.2f, ground);
        Movement();
        Jump();
        switchAnim();
    }




    void Movement()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);

        if (horizontalMove != 0)
        {
            transform.localScale = new Vector3(horizontalMove, 1, 1);
        }
    }

    void Jump()
    {
        if (isGround && jumpPressed == true)
        {
            isJump = true;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpPressed = false;
        }
    }

    void switchAnim()
    {
        anim.SetFloat("Run", Mathf.Abs(horizontalMove));

        if (isGround)
        {
            anim.SetBool("Down", false);
        }
        else if (rb.velocity.y > 0)
        {
            anim.SetBool("Jump", true);
        }
        else if (rb.velocity.y < 0)
        {
            anim.SetBool("Jump", false);
            anim.SetBool("Down", true);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("cherry"))
        {
            cherryCount++;
            cherryText.text = cherryCount.ToString();
            Destroy(collision.gameObject);

        }
     
    }

}
