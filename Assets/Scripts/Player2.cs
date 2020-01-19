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
}
