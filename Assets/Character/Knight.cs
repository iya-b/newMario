using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    Animator animator;

    Rigidbody2D rigidbody;

    bool onGround = true;

    private bool onStair;

    [SerializeField]
    float jumpForce;

    [SerializeField]
    float speed;

   
    float stairSpeed =5;
    public bool OnStair
    {
        get { return onStair; }
        set
        {
            if (value)
            {
                rigidbody.gravityScale = 0;
            }
            else
            {
                rigidbody.gravityScale = 1;
            }
            onStair = value;
        }


    }


    [SerializeField]
    Transform GroundCheck;
    void Awake()
    {
        animator = gameObject.GetComponentInChildren<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();


    }
    void Start()
    {

    }


    private bool CheckGround()
    {
        RaycastHit2D[] hits = Physics2D.LinecastAll(transform.position, GroundCheck.position);

        for (int i = 0; i < hits.Length; i++)
        {
            if (!GameObject.Equals(hits[i].collider.gameObject, gameObject))
            {
                return true;
            }
        }
        return false;
    }


    void Update()
    {
        onGround = CheckGround();
        animator.SetFloat("speed", Mathf.Abs(Input.GetAxis("Horizontal")));
        Vector2 velocity = rigidbody.velocity;
        velocity.x = Input.GetAxis("Horizontal") * speed;
        rigidbody.velocity = velocity;


        animator.SetBool("Jump", !onGround);
        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("Attack");
        }

        if (transform.localScale.x < 0)
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                transform.localScale = Vector3.one;
            }
        }
        else
        {
            if (Input.GetAxis("Horizontal") < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        if (Input.GetButtonDown("Jump") && onGround)
        {
            rigidbody.AddForce(Vector2.up * jumpForce);
        }
        if (OnStair)
        {
            velocity = rigidbody.velocity;
            velocity.y = Input.GetAxis("Vertical") * stairSpeed;
            rigidbody.velocity = velocity;
        }

    }

}

