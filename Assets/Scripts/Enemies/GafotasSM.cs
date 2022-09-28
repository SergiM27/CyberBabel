using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GafotasSM : EnemyController
{

    public float limitDistance;
    public float damageDistance;
    public GameObject explosion;
    public GameObject explosionObject;
    public int damage;
    public bool isPunching;
    public GameObject collider1;
    public GameObject collider2;

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
        isPunching = false;
        SetEnemyLevels();
    }

    private void FixedUpdate()
    {
        if (isPunching == false)
        {
            if (Vector3.Distance(player.transform.position, transform.position) >= limitDistance && isDead == false)
            {
                rb.velocity = (transform.forward * movementSpeed);
            }
            else
            {
                int r = Random.Range(0, 3);
                animator.SetBool("HitPlayer", true);
                animator.SetInteger("RandomHit", r);
                isPunching = true;
                rb.velocity = new Vector3(0, 0, 0);
            }
        }
    }

    public void Collider1Active()
    {
        collider1.SetActive(true);
    }

    public void Collider2Active()
    {
        collider2.SetActive(true);
    }

    public void IsPunchingOff()
    {
        animator.SetBool("HitPlayer", false);
        collider1.SetActive(false);
        collider2.SetActive(false);
        Invoke("StopPunching",0.4f);
    }

    public void StopPunching()
    {
        isPunching = false;
    }

    public void SetEnemyLevels()
    {
        health = 8 + (GameManager.currentEnemyMaxHPLevel * 4);
        movementSpeed = 0.8f + (GameManager.currentEnemyMovementSpeed * 0.1f);
        damage = 8 + (GameManager.currentEnemyAttackLevel * 3);
    }

    public override void IsDead()
    {
        if (health <= 0)
        {
            if (Vector3.Distance(player.transform.position, transform.position) <= damageDistance / 2)
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
