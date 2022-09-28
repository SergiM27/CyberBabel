using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMyself : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyThis", 5.0f);
    }

    private void DestroyThis()
    {
        Destroy(this.gameObject);
    }
}
