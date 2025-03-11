using UnityEngine;
using System.Collections.Generic;

public class CarBody : MonoBehaviour
{
    public List<WheelCollider> wheelsColliders;
    public int wheelsOnGround;
    public List<Wheel> wheelMeshes;
    public float velocity = 20f;
    private float rotation = 50f;
    public float acceleration = 0.01f;
    private float deceleration = 0.001f;
    private float maxSpeed = 100f;
    private float minSpeed = 0f;
    
    public CarBody Auto;
    
    public bool canMove;
    private Vector3 initialPos;
    private Quaternion initialRot;
    private float forceJump = 500f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        initialPos = transform.position;
        initialRot = transform.rotation;
        

    }

    // Update is called once per frame
    void Update()
    {
        
        CheckIfCanMove();
        if (canMove == true)
        {
            Move();
        }

        if (Input.GetKey(KeyCode.W))
        {

            velocity = Mathf.Lerp(velocity, maxSpeed, acceleration * Time.deltaTime);
            acceleration++;
            
        }
        else
        {
            velocity -= (velocity / maxSpeed) * deceleration * Time.deltaTime;
            velocity = Mathf.Max(velocity, minSpeed);
            
            acceleration = 0.00001f;
        }




            wheelsOnGround = 0;

        foreach (WheelCollider wheel in wheelsColliders)
        {
            if (wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        }
        if (Input.GetKey(KeyCode.F))
        {
            transform.position = initialPos;
            transform.rotation = initialRot;
        }



    }
    void CheckIfCanMove()
    {
        if(wheelsOnGround > 0)
        {
            canMove = true;
        }
        else
        {
            canMove = false;
        }
        
    }
    void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * velocity * Time.deltaTime;
            

            foreach (var wheel in wheelsColliders)
            {
                wheel.transform.position = wheel.transform.position;
            }
            

        }
        else
        {
            velocity = 20f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            foreach (var wheel in wheelsColliders)
            {
                wheel.transform.position = wheel.transform.position;
            }
            transform.position -= transform.forward * velocity * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
        {

            transform.Rotate(Vector3.down * rotation * Time.deltaTime);

            foreach (var wheel in wheelsColliders)
            {
                wheel.transform.position = wheel.transform.position;
            }
            wheelMeshes[0].transform.Rotate(Vector3.down * rotation * Time.deltaTime);
            wheelMeshes[1].transform.Rotate(Vector3.down * rotation * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
        {

            transform.Rotate(Vector3.up * rotation * Time.deltaTime);

            foreach (var wheel in wheelsColliders)
            {
                wheel.transform.position = wheel.transform.position;
            }
            wheelMeshes[0].transform.Rotate(Vector3.up * rotation * Time.deltaTime);
            wheelMeshes[1].transform.Rotate(Vector3.up * rotation * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
        {

            transform.Rotate(Vector3.up * rotation * Time.deltaTime);
            foreach (var wheel in wheelsColliders)
            {
                wheel.transform.position = wheel.transform.position;
            }
        }
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
        {

            transform.Rotate(Vector3.down * rotation * Time.deltaTime);
            foreach (var wheel in wheelsColliders)
            {
                wheel.transform.position = wheel.transform.position;
            }
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            rotation = 200f;
            velocity = 15f;
            acceleration = 0f;
        }
        else
        {
            rotation = 50f;
            velocity = 20f;
            
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y * forceJump * Time.deltaTime, transform.position.z);
        }
    }
    
    
}
