using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RawImageUpper : MonoBehaviour
{



    [SerializeField] private RawImage _rawImage;
    [SerializeField] private float _y;


    // Update is called once per frame
    void Update()
    {
        _rawImage.uvRect = new Rect(_rawImage.uvRect.position + new Vector2(0, _y) * Time.deltaTime, _rawImage.uvRect.size);
    }
}
