using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    public float speed;
    public float damage;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject newParticles = ObjectPooler.Instance.GetPooledObject("PlayerBulletParticles", transform.position, collision.transform.rotation);
        newParticles.GetComponent<ParticleSystem>().Play();
        
        if (collision.gameObject.tag == "Obstacle")
        {
            this.gameObject.SetActive(false);
        }
        else if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyController>().health -= damage;
            collision.gameObject.GetComponent<EnemyController>().IsDead();
            this.gameObject.SetActive(false);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
        AudioManager.instance.PlaySFX6("BulletHit");
    }
}
