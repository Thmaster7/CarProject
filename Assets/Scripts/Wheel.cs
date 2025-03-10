using UnityEngine;

public class Wheel : MonoBehaviour
{
    
    private bool onGround;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Piso"))
        {
            onGround = true;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Piso"))
        {
            onGround = false;
        }
            
    }
    public bool IsOnGround()
    {
        return onGround;
    }
    
}
