using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookScript : MonoBehaviour
{
    public int lookMode = 1;
    public float lookSpeed = 50;
    public bool inverted = false;
    void Start()
    {
        if (lookMode == 2) 
        {
            transform.rotation = Quaternion.Euler(0, 0, 70);
        }

        if (lookMode == 3)
        {
            transform.rotation = Quaternion.Euler(0, 0, 160);
        }
    }

    void Update()
    {
        if (lookMode == 1)
        {
            transform.Rotate(new Vector3(0, 0, lookSpeed) * Time.deltaTime);
        }

        if (lookMode == 2)
        {
            transform.Rotate(new Vector3(0, 0, lookSpeed) * (0.15f * Time.deltaTime));
            if (transform.rotation == Quaternion.Euler(0, 0, 110))
            {
                transform.rotation = Quaternion.Euler(0, 0, -110);
            }

            if (transform.rotation == Quaternion.Euler(0, 0, -70))
            {
                transform.rotation = Quaternion.Euler(0, 0, 70);
            }
        }

        if (lookMode == 3)
        {
            transform.Rotate(new Vector3(0, 0, lookSpeed) * (0.15f * Time.deltaTime));
            if (transform.rotation == Quaternion.Euler(0, 0, 200))
            {
                transform.rotation = Quaternion.Euler(0, 0, -20);
            }

            if (transform.rotation == Quaternion.Euler(0, 0, 20))
            {
                transform.rotation = Quaternion.Euler(0, 0, 160);
            }
        }
        Invert();
    }

    void Invert()
    {
        if (inverted == true)
        {
            lookSpeed *= -1;
        } 
    }
}
