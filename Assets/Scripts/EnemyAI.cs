using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
public Transform target;
 public float MoveSpeed = 20f;
 public float MaxDist = 5f;
 public float MinDist = 1f;

    void Update()
    {
        float dist = Vector3.Distance(target.position, transform.position);

        if (dist < MaxDist) {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, MoveSpeed);
        }
        
    }
            private void OnCollisionEnter2D(Collision2D collision) {
            if (collision.collider.gameObject.CompareTag("projectile")) {
                Destroy(gameObject);
            }
        }
}
