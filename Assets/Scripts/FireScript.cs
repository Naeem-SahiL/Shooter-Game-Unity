using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour
{
    float speed = 20f;
    public GameObject effectPrefab;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;

        StartCoroutine(WaitAndDestroy());
    }
    void OnCollisionEnter2D(Collision2D other) {
        if(other !=  null)
        {
            // Debug.Log("collision");
            Instantiate(effectPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        
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
