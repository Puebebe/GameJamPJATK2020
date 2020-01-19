using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : Player
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            rb.AddForce(new Vector2(0, jumpSpeed));
            isGrounded = false;

            animator.SetBool("isGrounded", false);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetBool("isMove", true);
            rb.AddForce(Vector2.left * speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(new Vector2(0, 180));
        }
        else
        {
            animator.SetBool("isMove", false);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetBool("isMove", true);
            rb.AddForce(Vector2.right * speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(new Vector2(0, 0));
        }
        else
        {
            animator.SetBool("isMove", false);
        }

        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            animator.SetTrigger("isShoot");
            Gun gun = GetComponentInChildren<Gun>();
            gun?.Fire();
        }
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
            uiManager?.AddScorePlayer(player: 1);
            uiManager.StartCoroutine(PlayerResetAfterSeconds(3));
        }
    }

    private IEnumerator PlayerResetAfterSeconds(int seconds)
    {
        gameObject.SetActive(false);
        yield return new WaitForSeconds(seconds);
        transform.position = startPosition;
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0;
        transform.rotation = Quaternion.identity;
        gameObject.SetActive(true);
        speed = startSpeed;
        transform.localScale = startScale;
    }
}
