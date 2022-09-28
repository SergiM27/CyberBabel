using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{

    public bool isFiring;

    public float bulletSpeed;
    public float bulletDamage;

    public float cadency;
    private float currentCadency;

    public Transform firePosition;

    public ParticleSystem shootingParticles;

    public GameObject bulletParent;

    // Update is called once per frame
    void Update()
    {
        currentCadency -= Time.deltaTime;
        if (isFiring)
        {
            if (currentCadency <= 0)
            {
                FireBullet();
                currentCadency = cadency;
            }
        }
    }

    private void FireBullet()
    {
        GameObject newBullet = ObjectPooler.Instance.GetPooledObject("PlayerBullet", firePosition.position, firePosition.rotation);
        newBullet.name = "PlayerBullet";
        newBullet.GetComponent<BulletController>().speed = bulletSpeed;
        newBullet.GetComponent<BulletController>().damage = bulletDamage;
        newBullet.transform.parent = bulletParent.transform;
        if(AudioManager.instance!=null)
        AudioManager.instance.PlaySFX2("PlayerShoot");
        shootingParticles.Play();
    }
}
