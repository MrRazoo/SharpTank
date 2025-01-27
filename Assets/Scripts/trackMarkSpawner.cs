using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trackMarkSpawner : MonoBehaviour
{
    public Vector2 lastLocation;
    public float trackDistance = 0.2f;
    public GameObject prefab;
    private ObjectPool pool;
    public int poolSize = 20;
    
    private void Awake()
    {
        pool = GetComponent<ObjectPool>();  
    }
    void Start()
    {
        lastLocation = transform.position;  
        pool.Initialize(prefab, poolSize);
    }

    // Update is called once per frame
    void Update()
    {
        var distanceDriven = Vector2.Distance(transform.position, lastLocation);
        if(distanceDriven > trackDistance)
        {
            lastLocation = transform.position;
            var track = pool.CreateObject(); // assign each Instantiated prefab to new var.
            track.transform.position = transform.position;
            track.transform.rotation = transform.rotation;
        }
    }
}
