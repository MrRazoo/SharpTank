using UnityEngine;
using System;
public abstract class AIBehaviour : MonoBehaviour
{
    public abstract void PerformAction(TankController tank, AiDetector detector);
}
