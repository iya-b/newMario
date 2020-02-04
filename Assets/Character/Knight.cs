using UnityEngine;

public class Knight : Creature 
{
   
    bool onGround = true;

    private bool onStair;

    [SerializeField]
    float jumpForce=300;

    [SerializeField]
    Transform attackPoint;

    [SerializeField]
    float attackRange;

    [SerializeField]
    float hitDelay;

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
    private void Attack()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, attackRange);

        for (int i = 0; i < hits.Length; i++)
        {
            if (!GameObject.Equals(hits[i].gameObject, gameObject))
            {
                IDestructable destructable = hits[i].gameObject.GetComponent<IDestructable>();
                if (destructable != null)
                {
                    Debug.Log("Hit " + destructable.ToString());
                    destructable.Hit(damage);
                    break;
                }
            }
        }
    }

    void Start()
    {
        health = GameController.Instance.MaxHealth;
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
            //Attack();
            Invoke("Attack", hitDelay);
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

