using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    protected Rigidbody rb;
    public float movementSpeed;

    public PlayerController player;
    public GameObject enemyObj;
    public float health;
    protected bool isDead;
    public float rotationDamping;
    protected Animator animator;

    protected Spawner spawn;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = FindObjectOfType<PlayerController>();
        animator = GetComponent<Animator>();
        enemyObj = FindObjectOfType<PlayerController>().gameObject;
        isDead = false;
        spawn = FindObjectOfType<Spawner>();
    }

    public virtual void IsDead()
    {
        if (health <= 0)
        {
            spawn.enemiesKilled++;
            Destroy(this.gameObject);
        }
    }

    public virtual void Die()
    {
        spawn.enemiesKilled++;
        Destroy(this.gameObject);
    }

    public virtual void LookAt()
    {
        var lookPos = enemyObj.transform.position - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationDamping);
    }
}
