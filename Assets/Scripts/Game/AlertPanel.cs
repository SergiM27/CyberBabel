using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertPanel : MonoBehaviour
{

    public Material[] panelMaterials;
    public int i;
    public bool up;

    // Start is called before the first frame update
    void Start()
    {
        up = true;
        i = 0;
        StartCoroutine("ChangePanel");
    }

    IEnumerator ChangePanel()
    {
        this.gameObject.GetComponent<Renderer>().material = panelMaterials[i];
        yield return new WaitForSeconds(0.08f);
        if (up == true)
        {
            i++;
        }
        else
        {
            i--;
        }
        if (i >= panelMaterials.Length - 1)
        {
            up = ! up;
        }
        if (i < 1)
        {
            up = ! up;
        }
        StartCoroutine(ChangePanel());
    }
}
