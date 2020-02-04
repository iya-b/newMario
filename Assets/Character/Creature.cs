using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour, IDestructable
{
    protected Animator animator;
    protected Rigidbody2D rigidbody;
    [SerializeField] protected float speed;
    [SerializeField] protected float damage;
    [SerializeField] protected float health;
    public float Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
        }
    }
    void Awake()
    {
        animator = gameObject.GetComponentInChildren<Animator>();
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public void Hit(float damage)
    {

        health -= damage;
        GameController.Instance.Hit(this);
        if (health <= 0)
        {
            Die();
        }
    }
     void Start()
    {
        
    }
    void Update()
    {
        
    }
}
