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

    protected float startSpeed;
    protected Vector3 startScale;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isGrounded = true;
        startPosition = transform.position;
        animator = GetComponent<Animator>();
        startSpeed = speed;
        startScale = transform.localScale;
    }
}
