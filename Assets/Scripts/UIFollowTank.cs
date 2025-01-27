using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFollowTank : MonoBehaviour
{
    public Transform tank;
    RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if(tank != null)
        {
            rectTransform.anchoredPosition = tank.localPosition;
        }
    }
}
