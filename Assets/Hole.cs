using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Hole : MonoBehaviour
{
    public UnityEvent onEnter;

    void OnCollisionEnter(Collision c)
    {
        BallBehaviourScript ball = c.collider.GetComponent<BallBehaviourScript>();
        if (ball != null) onEnter.Invoke();
    }
}
