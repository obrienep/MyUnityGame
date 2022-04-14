using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
     public GameObject objectToSpawn;
    public GameObject parent;
    public int numberToSpawn;
    public int limit = 20;
    public float rate;
    private Vector3 faceDirection = new Vector3(1,1,1);
 
    float spawnTimer;
 
    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = rate;
    }
 
    // Update is called once per frame
    void Update()
    {
        if (parent.transform.childCount < limit)
        {
            spawnTimer -= Time.deltaTime;
            if (spawnTimer <= 0f)
            {
                for (int i = 0; i < numberToSpawn; i++)
                {
                    faceDirection.x = 1;
                    if (Random.value < 0.5f) { faceDirection.x = -1;}
                    
                    GameObject test = Instantiate(objectToSpawn, new Vector3(this.transform.position.x + GetModifier(), this.transform.position.y + GetModifier())
                    , Quaternion.identity, parent.transform);
                        test.transform.localScale = faceDirection;
                        
                }
                spawnTimer = rate;
            }
        }
    }
 
    float GetModifier()
    {
        float modifier = Random.Range(0f, 1f);
        if (Random.Range(0, 2) > 0)
            return -modifier;
        else
            return modifier;
    }
}
