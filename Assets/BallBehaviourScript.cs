using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
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
        }

        if (Input.GetMouseButtonUp(0)) Hit(appliedForce);
    }

    public void Hit(float force)
    {
        Vector3 dir = heading.forward;
        rb.AddForce(dir * force);
    }
}
