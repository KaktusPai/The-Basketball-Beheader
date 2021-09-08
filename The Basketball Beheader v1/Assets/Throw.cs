using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Throw : MonoBehaviour
{
    public GameObject player;

    public Transform firePoint;
    public GameObject ballPrefab;

    public float ballForce = 13f;
    public float travelTime;
    public GameObject currentBall;
    public float time = 0;
    public float chargeTime = 5;
    public bool mouseDown = false;
    public Slider charge;

    void Update()
    {
        charge.value = time;
        charge.maxValue = chargeTime;
        ChargeBall();
    }

    void ChargeBall()
    {
        // Mouse down check
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Mouse DOWN");
            mouseDown = true;
        }

        // Updating the charge meter
        if (mouseDown == true)
        {
            time += Time.deltaTime;
            Debug.Log("Charging");
        } else
        {
            time = 0;
        }

        // Mouse up check
        if (Input.GetButtonUp("Fire1"))
        {
            Debug.Log("Mouse UP");
            if (time >= chargeTime)
            {
                ThrowBall();
                Debug.Log("THROWING");
            }
            mouseDown = false;
        }
    }

    void ThrowBall()
    {
        Debug.Log("Ball instantiated");
        currentBall = (Instantiate(ballPrefab, firePoint.position, firePoint.rotation) as GameObject);
        Rigidbody2D rb = currentBall.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * ballForce, ForceMode2D.Impulse);
    }
}
