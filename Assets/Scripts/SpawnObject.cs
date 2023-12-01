using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject prefab;
    public float spawnSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            Spawn();
        }
    }

    void Spawn()
    {
        GameObject obj = Instantiate(prefab, transform.position, Quaternion.identity);
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        rb.velocity = transform.forward * spawnSpeed;
    }
}
