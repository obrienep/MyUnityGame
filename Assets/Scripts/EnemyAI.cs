using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
public Transform target;
 public float MoveSpeed = 20f;
 public float MaxDist = 5f;
 public float MinDist = 1f;

 bool alive = true;

 public Animator animator;
 Rigidbody2D _rb;

    void Start() {
        animator = gameObject.GetComponent<Animator>();
        _rb = gameObject.GetComponent<Rigidbody2D>();

    }
    void Update()
    {
        float dist = Vector3.Distance(target.position, transform.position);

        if (dist < MaxDist && alive == true) {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, MoveSpeed);
        }
    }
            private void OnCollisionEnter2D(Collision2D collision) {
            if (collision.collider.gameObject.CompareTag("projectile")) {
                alive = false;
                animator.SetTrigger("Die");
                gameObject.GetComponent<CircleCollider2D>().enabled = false;
                _rb.constraints = RigidbodyConstraints2D.FreezeAll;
                Destroy(gameObject, 1);
            }
        }
}
