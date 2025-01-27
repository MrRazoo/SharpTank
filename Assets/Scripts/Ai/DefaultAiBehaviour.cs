using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultAiBehaviour : MonoBehaviour
{
    [SerializeField]
    private AIBehaviour shootBehaviour, patrolBehaviour;
    private AiDetector detector;
    private TankController tank;

    private void Awake()
    {
        detector = GetComponentInChildren<AiDetector>();
        tank = GetComponentInChildren<TankController>();
    }

private void Update()
{
    if(detector.IsTargetVisible)
    {
        shootBehaviour.PerformAction(tank, detector);
    }
    else
    {
        patrolBehaviour.PerformAction(tank, detector);
    }
}

}



