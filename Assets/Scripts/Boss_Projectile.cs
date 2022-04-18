using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Projectile : MonoBehaviour
{
    float moveSpeed = 1.5f;

    Rigidbody2D rb;

    PlayerController target;

    Vector3 moveDirection;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindObjectOfType<PlayerController>();
        moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        rb.velocity = new Vector3 (moveDirection.x, moveDirection.y, moveDirection.z);
            Destroy (gameObject, 5f);
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision) {
            Destroy(gameObject);
        }
}
