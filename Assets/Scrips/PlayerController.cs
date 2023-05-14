using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private GameObject Player;

    [SerializeField]
    private float JumpForce,SpeedMovement;

    public Camera Micamara;


    Rigidbody Rb;

    Vector3 Scale;


    private 
    // Start is called before the first frame update
    void Start()
    {
        Rb = Player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        Player.transform.position += new Vector3(horizontalInput * SpeedMovement * Time.deltaTime, 0, 0);
        Micamara.transform.position = new Vector3(Player.transform.position.x, Micamara.transform.position.y, Micamara.transform.position.z);
        Micamara.transform.LookAt(Player.transform);


        if (Input.GetKeyDown(KeyCode.Space))
        {
           Rb.velocity = new Vector3(0,JumpForce,0);
        }

        Scale = Player.transform.localScale;

        if (horizontalInput < 0)
        {
            Player.transform.localScale = new Vector3(Scale.x, Scale.y, -Mathf.Abs(Scale.z));
        }
        else if(horizontalInput > 0)
        {
            Player.transform.localScale = new Vector3(Scale.x, Scale.y, Mathf.Abs(Scale.z));
        }

    }
}
