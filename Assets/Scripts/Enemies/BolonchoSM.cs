using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolonchoSM : EnemyController
{
    void Update()
    {
        transform.LookAt(enemyObj.transform.position, Vector3.up);
    }

    private void FixedUpdate()
    {
        rb.velocity = (transform.forward * movementSpeed);
    }
}
