using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSM : EnemyController
{

    public float limitDistance;
    public float damageDistance;
    public GameObject explosion;
    public GameObject explosionObject;
    public int damage;

    void Update()
    {
        LookAt();
        if (health <= 0)
        {
            isDead = true;
            IsDead();
        }
    }

    private void OnEnable()
    {
        SetEnemyLevels();
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(player.transform.position, transform.position) >= limitDistance && isDead == false)
        {
            rb.velocity = (transform.forward * movementSpeed);
        }
        else
        {
            isDead = true;
            animator.SetBool("Death", true);
        }
    }

    public void SetEnemyLevels()
    {
        health = 3 + (GameManager.currentEnemyMaxHPLevel * 3);
        movementSpeed = 1.2f + (GameManager.currentEnemyMovementSpeed * 0.3f);
        damage = 15 + (GameManager.currentEnemyAttackLevel * 5);
    }

    public override void IsDead()
    {
        if (health <= 0)
        {
            if (Vector3.Distance(player.transform.position, transform.position) <= damageDistance/2)
            {
                player.gameObject.GetComponent<PlayerController>().TakeDamage(damage);
            }
            AudioManager.instance.PlaySFX7("Explosion");
            Instantiate(explosion, explosionObject.transform.position, Quaternion.identity);
            spawn.enemiesKilled++;
            Destroy(this.gameObject);
        }
    }

    public override void Die()
    {
        if (Vector3.Distance(player.transform.position, transform.position) <= damageDistance)
        {
            player.gameObject.GetComponent<PlayerController>().TakeDamage(damage);
        }
        AudioManager.instance.PlaySFX7("Explosion");
        Instantiate(explosion, explosionObject.transform.position, Quaternion.identity);
        spawn.enemiesKilled++;
        Destroy(this.gameObject);
    }

}
