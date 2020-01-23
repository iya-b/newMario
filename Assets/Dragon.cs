using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    [SerializeField]
    private float health = 100;
   
    [SerializeField]
    private float speed;
    public float Health
    {
    get { return health; }
    set { health = value; }
    }

    private Rigidbody2D rigidbody;
    private Animator animator;

    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 velocity = rigidbody.velocity;
        velocity.x = speed * transform.localScale.x * -1;
        rigidbody.velocity = velocity;

    }
    private void OnTriggerStay2D(Collider2D collider)
    {
        Knight knight = collider.gameObject.GetComponent<Knight>();

        if (knight != null)
        {
            animator.SetTrigger("Attack");
        }
        else
        {
            ChangeDirection();
        }
    }
    private void ChangeDirection()
    {
        if (transform.localScale.x < 0)
        {
            transform.localScale = Vector3.one;
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

    }
}
