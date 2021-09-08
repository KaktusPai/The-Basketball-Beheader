using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    float time;
    void Update()
    {
        Despawn();
    }
    void Despawn()
    {
        time += Time.deltaTime;
        if (time >= 4)
        {
            Destroy(this.gameObject);
        }
    }
}
