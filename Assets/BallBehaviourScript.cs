using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallBehaviourScript : MonoBehaviour
{
    public float appliedForce;
    public float stopSpeed = 1;
    public Transform heading;
    private Rigidbody rb;
    
    private float elapsedTime;
    public float hitTime = 1;
    private float start, end;
    private float t;

    public Slider slider;

    private Vector3 spawnPos;

    public int hits;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        spawnPos = transform.position;
        hits = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) Respawn();

        if (rb.velocity.magnitude > stopSpeed) return;

        if (Input.GetMouseButtonDown(0))
        { 
            elapsedTime = 0;
            start = 0;
            end   = 1;
        }

        if (Input.GetMouseButton(0))
        { 
            t = Mathf.Lerp(start, end, elapsedTime / hitTime);
            elapsedTime += Time.deltaTime;
            if (elapsedTime > hitTime)
            {
                elapsedTime = 0;
                float temp = start;
                start = end;
                end   = temp;
            }
            slider.value = t;
        }

        if (Input.GetMouseButtonUp(0)) Hit(appliedForce * t);
    }

    public void Hit(float force)
    {
        Vector3 dir = heading.forward;
        rb.AddForce(dir * force);
        hits++;
    }

    public void Respawn()
    {
        transform.position = spawnPos;
        rb.velocity        = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.rotation = Quaternion.identity;
    }
}
