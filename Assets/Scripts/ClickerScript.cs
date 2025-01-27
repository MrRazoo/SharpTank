using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickerScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    [SerializeField] private Image _image;
    [SerializeField] private Sprite _default,_pressed;
    [SerializeField] private AudioSource _auSource;
    [SerializeField] private AudioClip _pressedClip, _releasedClip;

    public void OnPointerDown(PointerEventData eventData)
    {
        _image.sprite = _pressed;
        _auSource.PlayOneShot(_pressedClip);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _image.sprite = _default;
        _auSource.PlayOneShot(_releasedClip);
    }
}
