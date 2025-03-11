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
    void OnCollisionEnter()
    {
        if (CompareTag("Piso"))
        {
            onGround = true;
        }
    }
    void OnCollisionExit()
    {
        if (CompareTag("Piso"))
        {
            onGround = false;
        }
            
    }
    public bool IsOnGround()
    {
        return onGround;
    }
    
}
