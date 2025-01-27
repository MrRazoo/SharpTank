using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// here just one thing remain thst is when object destroy the bullet gaeobject is false setActive rather to destroy ... still good Code fix it later. OK 
public class ObjectPool : MonoBehaviour
{
    [SerializeField]
    protected GameObject objectToPool; // Like bullets 
    [SerializeField]
    protected int poolSize; // pool size 
    protected Queue<GameObject> objectpool; // like a water pool.
    public Transform spawnedObjectsParent;
    public Boolean alwaysDestroy = false;

    private void Awake()
    {
        objectpool = new Queue<GameObject>();
    }

    public void Initialize(GameObject objectToPool, int poolSize) // this is just to set bullet prefab and pool count number from here (Optional)
    {
        this.objectToPool = objectToPool;
        this.poolSize = poolSize;
    }

    public GameObject CreateObject()
    {
        CreateObjectParentIfNeeded();
        GameObject spawnedObject = null;
        if(objectpool.Count < poolSize) // pool has less number of obj than Max limit 
        {
            spawnedObject = Instantiate(objectToPool, transform.position, Quaternion.identity);
            spawnedObject.name = transform.root.name + "_" + objectToPool.name + "_" + objectpool.Count;
            spawnedObject.transform.SetParent(spawnedObjectsParent);
        }
        else // if all objects instantialte reusing them
        {
            spawnedObject = objectpool.Dequeue();
            spawnedObject.transform.position = transform.position;
            spawnedObject.transform.rotation = Quaternion.identity;
            spawnedObject.SetActive(true);
        }

        objectpool.Enqueue(spawnedObject);
        return spawnedObject;

    }

    private void CreateObjectParentIfNeeded()
    {
        if(spawnedObjectsParent == null)
        {
            string name = "ObjectPool_" + objectToPool.name;
            var parentObject = GameObject.Find(name);
            if(parentObject != null) 
            spawnedObjectsParent = parentObject.transform;
            else
            {
                spawnedObjectsParent = new GameObject(name).transform;
            }
        }
    }
/*  it used to destroy the ObjectPool all objects only needs if u have multiple levels to swap out pools element 
    private void OnDestroy()
    {
        foreach(var item in objectpool)
        if(item == null)
        continue;

        else if(item.activeSelf == false || alwaysDestroy)
        Destroy(item);

        
    }
*/

}
