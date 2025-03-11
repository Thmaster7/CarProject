using UnityEngine;

public class CarBody : MonoBehaviour
{
    public Wheel wheel1, wheel2, wheel3, wheel4;
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
                //transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + velocity * Time.deltaTime);
                wheel1.transform.position = new Vector3(wheel1.transform.position.x, wheel1.transform.position.y, wheel1.transform.position.z);
                wheel2.transform.position = new Vector3(wheel2.transform.position.x, wheel2.transform.position.y, wheel2.transform.position.z);
                wheel3.transform.position = new Vector3(wheel3.transform.position.x, wheel3.transform.position.y, wheel3.transform.position.z);
                wheel4.transform.position = new Vector3(wheel4.transform.position.x, wheel4.transform.position.y, wheel4.transform.position.z);
                transform.position += transform.forward * velocity * Time.deltaTime;
            
            }
            if (Input.GetKey(KeyCode.S))
            {
                //transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - velocity * Time.deltaTime);
                wheel1.transform.position = new Vector3(wheel1.transform.position.x, wheel1.transform.position.y, wheel1.transform.position.z);
                wheel2.transform.position = new Vector3(wheel2.transform.position.x, wheel2.transform.position.y, wheel2.transform.position.z);
                wheel3.transform.position = new Vector3(wheel3.transform.position.x, wheel3.transform.position.y, wheel3.transform.position.z);
                wheel4.transform.position = new Vector3(wheel4.transform.position.x, wheel4.transform.position.y, wheel4.transform.position.z);
                transform.position -= transform.forward * velocity * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
            {
            //transform.position = new Vector3(transform.position.x - velocity * Time.deltaTime, transform.position.y, transform.position.z + velocity * Time.deltaTime);
            //transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y - rotation * Time.deltaTime, transform.rotation.z, transform.rotation.w);
            transform.Rotate(Vector3.down * rotation * Time.deltaTime);
                
                wheel1.transform.position = new Vector3(wheel1.transform.position.x, wheel1.transform.position.y, wheel1.transform.position.z);
                wheel2.transform.position = new Vector3(wheel2.transform.position.x, wheel2.transform.position.y, wheel2.transform.position.z);
                wheel3.transform.position = new Vector3(wheel3.transform.position.x, wheel3.transform.position.y, wheel3.transform.position.z);
                wheel4.transform.position = new Vector3(wheel4.transform.position.x, wheel4.transform.position.y, wheel4.transform.position.z);
                wheelMesh1.transform.Rotate(Vector3.down * rotation * Time.deltaTime);
                wheelMesh2.transform.Rotate(Vector3.down * rotation * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
            {
            //transform.position = new Vector3(transform.position.x + velocity * Time.deltaTime, transform.position.y, transform.position.z + velocity * Time.deltaTime);
            //transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y + rotation * Time.deltaTime, transform.rotation.z, transform.rotation.w);
            transform.Rotate(Vector3.up * rotation * Time.deltaTime);
                
                wheel1.transform.position = new Vector3(wheel1.transform.position.x, wheel1.transform.position.y, wheel1.transform.position.z);
                wheel2.transform.position = new Vector3(wheel2.transform.position.x, wheel2.transform.position.y, wheel2.transform.position.z);
                wheel3.transform.position = new Vector3(wheel3.transform.position.x, wheel3.transform.position.y, wheel3.transform.position.z);
                wheel4.transform.position = new Vector3(wheel4.transform.position.x, wheel4.transform.position.y, wheel4.transform.position.z);
                wheelMesh1.transform.Rotate(Vector3.up * rotation * Time.deltaTime);
                wheelMesh2.transform.Rotate(Vector3.up * rotation * Time.deltaTime);

            }
            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
            {
                //transform.position = new Vector3(transform.position.x - velocity * Time.deltaTime, transform.position.y, transform.position.z - velocity * Time.deltaTime);
                transform.Rotate(Vector3.up * rotation * Time.deltaTime);
                wheel1.transform.position = new Vector3(wheel1.transform.position.x, wheel1.transform.position.y, wheel1.transform.position.z);
                wheel2.transform.position = new Vector3(wheel2.transform.position.x, wheel2.transform.position.y, wheel2.transform.position.z);
                wheel3.transform.position = new Vector3(wheel3.transform.position.x, wheel3.transform.position.y, wheel3.transform.position.z);
                wheel4.transform.position = new Vector3(wheel4.transform.position.x, wheel4.transform.position.y, wheel4.transform.position.z);
            }
            if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
            {
                //transform.position = new Vector3(transform.position.x + velocity * Time.deltaTime, transform.position.y, transform.position.z - velocity * Time.deltaTime);
                transform.Rotate(Vector3.down * rotation * Time.deltaTime);
                wheel1.transform.position = new Vector3(wheel1.transform.position.x, wheel1.transform.position.y, wheel1.transform.position.z);
                wheel2.transform.position = new Vector3(wheel2.transform.position.x, wheel2.transform.position.y, wheel2.transform.position.z);
                wheel3.transform.position = new Vector3(wheel3.transform.position.x, wheel3.transform.position.y, wheel3.transform.position.z);
                wheel4.transform.position = new Vector3(wheel4.transform.position.x, wheel4.transform.position.y, wheel4.transform.position.z);
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
        if(wheel1.IsOnGround()|| wheel2.IsOnGround()|| wheel3.IsOnGround()|| wheel4.IsOnGround())
        {
            canMove = true;
        }
        else
        {
            canMove = false;
            
        }
    }

    
    
}
