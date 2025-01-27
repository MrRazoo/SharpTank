using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMe : MonoBehaviour
{
    // Start is called before the first frame update
    public void DestroyHelper()
    {
        Destroy(gameObject);
    }
}
