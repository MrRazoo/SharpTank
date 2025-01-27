using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateUtil : MonoBehaviour
{
    public GameObject gameObj;


    public void CallSoundPrefab()
    {
        Instantiate(gameObj);
    }
}
