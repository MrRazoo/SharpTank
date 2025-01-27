using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class objectgenerateRandomPositionUtils : MonoBehaviour
{
    public GameObject objectPrefab;
    public float radius = 0.2f;

    protected Quaternion Get2DRotation()
    {
        return Quaternion.Euler(0, 0, Random.Range(0, 360));
    }

    protected Vector2 GetRandomPosition()
    {
        return Random.insideUnitCircle * radius + (Vector2)transform.position;
    }

    public void CreateObject()
    {
        Vector2 Position = GetRandomPosition();
        GameObject impactObject = Instantiate(objectPrefab);
        impactObject.transform.position = Position;
        impactObject.transform.rotation = Get2DRotation();
    }

}
