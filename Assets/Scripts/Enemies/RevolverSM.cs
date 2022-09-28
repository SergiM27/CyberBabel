using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevolverSM : EnemyController
{
    public float limitDistance;
    public GameObject explosion;
    public GameObject explosionObject;
    public int damage;

    public float shootCD;
    private float currentShootCD;
    public float bulletSpeed;
    public int bulletDamage;

    public bool isShooting;
    public GameObject revolverBullet;
    public GameObject bulletSpawn;

    void Update()
    {
        LookAt();
        if (health <= 0)
        {
            isDead = true;
            IsDead();
        }
        currentShootCD -= Time.deltaTime;
        if (currentShootCD <= 0)
        {
            Shoot();
        }
    }

    private void OnEnable()
    {
        SetEnemyLevels();
        isShooting = false;
        currentShootCD = shootCD;
        isDead = false;
    }

    private void Shoot()
    {
        if (Vector3.Distance(player.transform.position, transform.position) <= limitDistance && isDead == false)
        {
            currentShootCD = shootCD;
            isShooting = true;
            animator.SetBool("Shoot", true);
        }
    }

    public void SpawnBullet()
    {
        GameObject newBullet = Instantiate(revolverBullet, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
        newBullet.name = "EnemyBullet";
        newBullet.GetComponent<RevolverBullet>().speed = bulletSpeed;
        newBullet.GetComponent<RevolverBullet>().damage = bulletDamage;
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(player.transform.position, transform.position) >= limitDistance && isDead == false)
        {
            rb.velocity = (transform.forward * movementSpeed);
        }
    }

    public void SetEnemyLevels()
    {
        health = 5 + (GameManager.currentEnemyMaxHPLevel * 3);
        movementSpeed = 1f + (GameManager.currentEnemyMovementSpeed * 0.2f);
        damage = 3 + (GameManager.currentEnemyAttackLevel * 2);
        shootCD = 1.5f - (GameManager.currentEnemyCadency * 0.1f);
        if (shootCD <= 0.4f)
        {
            shootCD = 0.4f;
        }
    }

    public void IsShootingOver()
    {
        animator.SetBool("Shoot", false);
        isShooting = false;
    }

    public override void IsDead()
    {
        if (health <= 0)
        {
            AudioManager.instance.PlaySFX7("Explosion");
            Instantiate(explosion, explosionObject.transform.position, Quaternion.identity);
            spawn.enemiesKilled++;
            Destroy(this.gameObject);
        }
    }

    public override void Die()
    {
        AudioManager.instance.PlaySFX7("Explosion");
        Instantiate(explosion, explosionObject.transform.position, Quaternion.identity);
        spawn.enemiesKilled++;
        Destroy(this.gameObject);
    }

}
