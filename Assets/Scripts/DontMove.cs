using UnityEngine;
 
public class DontMove : MonoBehaviour
{
    new Rigidbody2D rigidbody;
    public Vector2 position, velocity;
    public bool isColliding;
 
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
 
    void FixedUpdate()
    {
        if (!isColliding)
        {
            position = rigidbody.position;
            velocity = rigidbody.velocity;
            
        }
    }
 
    void LateUpdate()
    {
        if (isColliding)
        {
            rigidbody.position = position;
            rigidbody.velocity = velocity;
            
        }
    }
 
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "player")
            isColliding = true;
    }
 
    void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "player")
            isColliding = false;
    }
}