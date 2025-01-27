using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyAfterPlaySound : MonoBehaviour
{
    AudioSource Source;

    private void Awake()
    {
        Source = GetComponent<AudioSource>();
        
    }

    private void Start()
    {
        StartCoroutine(waitForMe());
    }
    
    IEnumerator waitForMe()
    {
        yield return new WaitForSeconds(Source.clip.length);
        Destroy(gameObject);
    }
    
}
