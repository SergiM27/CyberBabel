using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatSM : EnemyController
{
    public GameObject explosion;
    public GameObject explosionObject;
    public GameObject batBullet;
    public GameObject bulletSpawn;

    public float shootCD;
    private float currentShootCD;
    public float bulletSpeed;
    public int bulletDamage;

    public GameObject[] positions;
    private Vector3 currentPosition;
    public bool isShooting;

    private void OnEnable()
    {
        SetEnemyLevels();
        isShooting = false;
        currentShootCD = shootCD;
        positions = new GameObject[14];
        for (int i = 0; i < positions.Length; i++)
        {
            positions[i] = GameObject.Find("BatPositions").transform.GetChild(i).gameObject;
        }
        currentPosition = positions[Random.Range(0, positions.Length)].transform.position;
    }

    public void SetEnemyLevels()
    {
        health = 5 + (GameManager.currentEnemyMaxHPLevel * 3);
        bulletDamage = 5 + (GameManager.currentEnemyAttackLevel * 3);
        movementSpeed = 1 + (GameManager.currentEnemyMovementSpeed * 0.3f);
        shootCD = 2 - (GameManager.currentEnemyCadency * 0.2f);
        if(shootCD <= 0.4f)
        {
            shootCD = 0.4f;
        }
    }

    void Update()
    {
        if (!isShooting)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentPosition, Time.deltaTime * movementSpeed);
            if (Vector3.Distance(transform.position, currentPosition) <= 0.5f)
            {
                currentPosition = positions[Random.Range(0, positions.Length)].transform.position;
            }
        }
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
            currentShootCD = shootCD;
        }
    }

    private void Shoot()
    {
        isShooting = true;
        animator.SetBool("Shoot", true);
        GameObject newBullet = Instantiate(batBullet, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
        newBullet.name = "EnemyBullet";
        newBullet.GetComponent<BatBullet>().speed = bulletSpeed;
        newBullet.GetComponent<BatBullet>().damage = bulletDamage;
    }

    public void StopShooting()
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
