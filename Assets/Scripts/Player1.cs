using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    [SerializeField]
    private float speed = 700f;
    [SerializeField]
    private float jumpSpeed = 400f;
    [SerializeField]
    private float shootSpeed = 500f;

    private Rigidbody2D rb1;
    private bool isGrounded;


    // Start is called before the first frame update
    void Start()
    {
        rb1 = GetComponent<Rigidbody2D>();
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb1.AddForce(new Vector2(0, jumpSpeed));
            isGrounded = false;

            //   animator.SetBool("IsJumping", true);
        }
        if (Input.GetKey(KeyCode.A)){
            rb1.AddForce(Vector2.left* speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(new Vector2(0, 180));
        }
        if (Input.GetKey(KeyCode.D)){
            rb1.AddForce(Vector2.right* speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(new Vector2(0, 0));
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(transform.right);
            Debug.DrawLine(transform.position, transform.position + transform.right*5);
        }
}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
        if (collision.gameObject.tag == "Water")
        {
            Destroy(gameObject);
            var uiManager = FindObjectOfType<UIManager>();
            uiManager?.AddScorePlayer(player: 2);
        }
    }
}
