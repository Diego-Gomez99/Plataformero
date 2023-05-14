using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyScript : MonoBehaviour
{

    public Transform Target;

    public float Delay;
    private Vector3 TargetPosition, FollowPosition, Velocity, Scale;

    Rigidbody Rb;
    private void Start()
    {
        FollowPosition = transform.position;
        Rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Velocity = GetComponent<Rigidbody>().velocity;
        transform.LookAt(Target);

        /*
        Scale = transform.localScale;
        if (Velocity.z > 0)
        {
            transform.localScale = new Vector3(Scale.x, Scale.y, -Mathf.Abs(Scale.z));
        }
        else if (Velocity.z < 0)
        {
           transform.localScale = new Vector3(Scale.x, Scale.y, Mathf.Abs(Scale.z));
        }
        */
    }

    private void LateUpdate()
    {
        TargetPosition = Target.position;
        FollowPosition = Vector3.Lerp(FollowPosition, TargetPosition, Time.deltaTime/Delay);
        Rb.MovePosition(FollowPosition);
    }
}
