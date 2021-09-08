using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Move m;
    public GameObject blood;
    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "ball")
        {
            m.kills += 1;
            Debug.Log("hit guy!");
            Instantiate(blood, transform.position, collider.gameObject.transform.transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
