using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour
{
    //Private variables
    private Rigidbody rb;
    private Vector3 lastMousePos;
    private Animator anim;

    //Public variables
    public float Sensitivity = 0.16f, clampDelta = 42f;
    public float bounds = 5;
    public float Speed = 5;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        //This will give touch input to the game for player sliding left and right
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -1.60f, 1.60f), transform.position.y, transform.position.z);
        if (Input.GetMouseButtonDown(0))
        {
            lastMousePos = Input.mousePosition;
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Vector3 vector = lastMousePos - Input.mousePosition;
            lastMousePos = Input.mousePosition;
            vector = new Vector3(vector.x, 0);
            Vector3 moveForce = Vector3.ClampMagnitude(vector, clampDelta)*Speed*Time.deltaTime;
            rb.AddForce((-moveForce * Sensitivity - rb.velocity / 5f), ForceMode.VelocityChange);
        }

       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            Speed = 0;
            anim.SetBool("isFinish", true);
            
        }
    }
}
