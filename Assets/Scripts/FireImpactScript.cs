using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireImpactScript : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitAndDestroy());
    }

    IEnumerator WaitAndDestroy()
    {
        yield return new WaitForSeconds(2);
        if(gameObject != null)
        {
            Destroy(gameObject);
        }
    }
}
