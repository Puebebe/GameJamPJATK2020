using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : Player
{


    [SerializeField]
    private float jumpSpeed = 400f;
    private Rigidbody2D rb2;
    private bool isGrounded;
    private Vector2 startPosition;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        isGrounded = true;
        startPosition = transform.position;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) &&isGrounded)
        {
            rb2.AddForce(new Vector2(0, jumpSpeed));
            isGrounded = false;

            animator.SetBool("isGrounded", false);
        }
        if (Input.GetKey(KeyCode.LeftArrow)){
            animator.SetBool("isMove", true);
            rb2.AddForce(Vector2.left* speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(new Vector2(0,180));
        }
        else
        {
            animator.SetBool("isMove", false);
        }
        if (Input.GetKey(KeyCode.RightArrow)){
            animator.SetBool("isMove", true);
            rb2.AddForce(Vector2.right* speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(new Vector2(0, 0));
        }
        else
        {
            animator.SetBool("isMove", false);
        }
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            animator.SetTrigger("isShoot");
            Debug.Log(transform.right);
            Debug.DrawLine(transform.position, transform.position + transform.right * 5);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            animator.SetBool("isGrounded", true);
        }
        if (collision.gameObject.tag == "Water")
        {
            PlayerReset();
            var uiManager = FindObjectOfType<UIManager>();
            uiManager?.AddScorePlayer(player: 1);
        }

    }
    private void PlayerReset()
    {
        animator.SetBool("isGrounded", true);
        transform.position = startPosition;
        rb2.velocity = Vector2.zero;
        rb2.angularVelocity = 0;
        transform.rotation = Quaternion.identity;
    }
}
