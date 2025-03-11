using UnityEngine;

public class CameControll : MonoBehaviour
{
    public CarBody car;
    public float rotationSmoothSpeed = 2.5f;
    private Vector3 velocity = Vector3.zero;
    public Vector3 offset = new Vector3(0, 1, -5);
    public float smoothSpeed = 0.125f;
    private bool isOriginalPosition;
    private Vector3 originalOffset;
    private Vector3 modifiedOffset = new Vector3(1, 2, -1);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalOffset = offset;
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //transform.position = new Vector3(car.transform.position.x, car.transform.position.y + 0.5f, car.transform.position.z - 5);
        //transform.rotation = new Quaternion(car.transform.rotation.x, car.transform.rotation.y, car.transform.rotation.z, car.transform.rotation.w);
        Vector3 desiredPosition = car.transform.position + car.transform.TransformDirection(offset);
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
        Quaternion carRotation = Quaternion.LookRotation(car.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, carRotation, rotationSmoothSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.C))
        {
            if (isOriginalPosition)
            {
                offset = modifiedOffset;

            }
            else if (!isOriginalPosition)
            {
                offset = originalOffset;

            }
            isOriginalPosition = !isOriginalPosition;

        }
        if (Input.GetKey(KeyCode.S))
        {
            offset = new Vector3(0, 5, -7);
        }
        else
        {
            offset = originalOffset;
        }

    }
    
}
