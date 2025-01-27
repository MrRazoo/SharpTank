using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiShootBehaviour : AIBehaviour
{
    public float fieldOfVisionForShooting = 60;
    
    public override void PerformAction(TankController tank, AiDetector detector)
    {

        tank.HandleTurretRotation(detector.Target.position); // updates each seconds. 

        if(TargetInFOV(tank, detector)) // if in our range (within Angle view) then ... 
        {
            tank.HandleTankMovement(Vector2.zero);
            tank.HandleShoot();
        }

        
    }

    private bool TargetInFOV(TankController tank, AiDetector detector)
    {
        
        var direction = detector.Target.position - tank.aimTuret.transform.position;
        if(Vector2.Angle(tank.aimTuret.transform.right /* because aimturret faces in right so angle calculates from this side */, direction) < fieldOfVisionForShooting / 2)
        {
            
            return true;
        }
        return false;
    }

}
