using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyScript : MonoBehaviour
{

    public Transform Target,RaysCastPosition;
    public float RangoVision;
    private NavMeshAgent agent;
    public LayerMask Playerlayer;
    public float Delay;
    private Vector3 TargetPosition, FollowPosition, Velocity, Scale;

    Rigidbody Rb;
    private void Start()
    {
        FollowPosition = transform.position;
        Rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        Velocity = GetComponent<Rigidbody>().velocity;


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

      

        Ray ray = new Ray(RaysCastPosition.position, RaysCastPosition.forward);

        if(Physics.Raycast(ray,RangoVision,Playerlayer))
        {
            agent.SetDestination(Target.position);
           //transform.LookAt(Target);
        }
        else
        {
            //Realizar algun otro comportamiento cuando el jugador no está en su linea de vista
        }
       
    }

    //private void LateUpdate()
    //{
    //    TargetPosition = Target.position;
    //    FollowPosition = Vector3.Lerp(FollowPosition, TargetPosition, Time.deltaTime/Delay);
    //    Rb.MovePosition(FollowPosition);
    //}

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(RaysCastPosition.position, RaysCastPosition.forward * RangoVision);
    }
}
