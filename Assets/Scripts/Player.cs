using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 700;
    [SerializeField]
    protected float jumpSpeed = 400f;
    [SerializeField]
    protected float shootSpeed = 500f;

    protected Rigidbody2D rb;
    protected bool isGrounded;
    protected Vector2 startPosition;
    protected Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isGrounded = true;
        startPosition = transform.position;
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            animator.SetBool("isGrounded", true);
        }
        if (collision.gameObject.tag == "Water")
        {
            animator.SetTrigger("isDie");
            var uiManager = FindObjectOfType<UIManager>();
            uiManager?.AddScorePlayer(player: 2);
            uiManager.StartCoroutine(PlayerResetAfterSeconds(3));
        }
    }

    private IEnumerator PlayerResetAfterSeconds(int seconds)
    {
        //float speedBasic = speed;
        //float jumpSpeedBasic = jumpSpeed;
        //speed = 0;
        gameObject.SetActive(false);
        yield return new WaitForSeconds(seconds);
        transform.position = startPosition;
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0;
        transform.rotation = Quaternion.identity;
        gameObject.SetActive(true);
        //speed = speedBasic;
        //jumpSpeed = jumpSpeedBasic;

    }
}
