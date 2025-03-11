using UnityEngine;
using System.Collections.Generic;

public class CarBody : MonoBehaviour
{
    [SerializeField] List<Wheel> wheelsColliders;
    public Wheel wheelMesh1, wheelMesh2, wheelMesh3, wheelMesh4;
    private float velocity = 20f;
    private float rotation = 50f;
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
        





            if (Input.GetKey(KeyCode.W))
            {
            
            foreach (var wheel in wheelsColliders)
            {
                wheel.transform.position = wheel.transform.position;
            }
            transform.position += transform.forward * velocity * Time.deltaTime;
            
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
            wheelMesh1.transform.Rotate(Vector3.down * rotation * Time.deltaTime);
                wheelMesh2.transform.Rotate(Vector3.down * rotation * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
            {
            
            transform.Rotate(Vector3.up * rotation * Time.deltaTime);

            foreach (var wheel in wheelsColliders)
            {
                wheel.transform.position = wheel.transform.position;
            }
            wheelMesh1.transform.Rotate(Vector3.up * rotation * Time.deltaTime);
                wheelMesh2.transform.Rotate(Vector3.up * rotation * Time.deltaTime);

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
            if (Input.GetKey(KeyCode.F))
            {
                transform.position = initialPos;
                transform.rotation = initialRot;
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {
                rotation = 200f;
                velocity = 15f;
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
    void CheckIfCanMove()
    {
        /*if(wheel1.GetComponent<WheelCollider>(isGrounded)|| wheel2.IsOnGround()|| wheel3.IsOnGround()|| wheel4.IsOnGround())
        {
            canMove = true;
        }
        else
        {
            canMove = false;
            
        }*/
    }

    
    
}
