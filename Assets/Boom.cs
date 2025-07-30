using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    public float turnSpeed = 180;
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,
                         Input.GetAxis("Mouse X") * turnSpeed * Time.deltaTime,
                         0
                        );
        transform.position = target.position;
    }
}
