using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevolverBullet : MonoBehaviour
{
    // Update is called once per frame
    public float speed;
    public int damage;

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
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().TakeDamage(damage);
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        AudioManager.instance.PlaySFX5("BulletHit");
    }
}
