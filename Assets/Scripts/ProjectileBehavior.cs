using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    public float Speed = 3f;

    public int projectileNum = 1;


    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * Time.deltaTime * Speed;
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        Destroy(gameObject);
    }
}
