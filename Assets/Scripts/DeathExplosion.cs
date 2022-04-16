using UnityEngine;

public class DeathExplosion : MonoBehaviour
{
    public float Speed = 3f;



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
