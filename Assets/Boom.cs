using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    public float turnSpeed = 180;
    public Transform target;
    public float maxAngle = 60;
    public Camera cam;

    private Vector3 camSpawnPos;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        camSpawnPos = cam.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(0,
        //                 Input.GetAxis("Mouse X") * turnSpeed * Time.deltaTime,
        //                 0
        //                );

        transform.Rotate(Vector3.up    *  Input.GetAxis("Mouse X") * turnSpeed * Time.deltaTime, Space.World);

        transform.Rotate(Vector3.right * -Input.GetAxis("Mouse Y") * turnSpeed * Time.deltaTime, Space.Self);

        //Vector3 euler = transform.eulerAngles;
        //euler.x = Mathf.Clamp(euler.x, -maxAngle, maxAngle); 
        //transform.rotation = Quaternion.Euler(euler);

        transform.position = target.position;

        if (Physics.Raycast(transform.position,
                            (cam.transform.position - transform.position).normalized,
                            out RaycastHit hit
                           ))
            cam.transform.localPosition = transform.InverseTransformPoint(hit.point);
        else
            cam.transform.localPosition = camSpawnPos;
    }
}
