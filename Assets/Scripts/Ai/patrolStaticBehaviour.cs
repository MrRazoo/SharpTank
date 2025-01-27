using UnityEngine;

public class patrolStaticBehaviour : AIBehaviour
{
    public float patrolDelay = 4;
    [SerializeField]
    private Vector2 randomDirection = Vector2.zero;
    [SerializeField]
    private float currentPatrolDelay;
    private void Awake()
    {
        randomDirection = Random.insideUnitCircle; // in easy words it gives 2d random direction .
    }

    public override void PerformAction(TankController tank, AiDetector detector)
    {
        float angle = Vector2.Angle(tank.aimTuret.transform.right, randomDirection); // find the angle of turret and that random .
        if(currentPatrolDelay <= 0 && (angle < 2)) // both must fullfills .
        {
            randomDirection = Random.insideUnitCircle; // new random direction .
            currentPatrolDelay = patrolDelay; // set delay again to 4 .
        }
        else
        {
            if(currentPatrolDelay > 0)
            {
                currentPatrolDelay -= Time.deltaTime;
            }
            else // currentPatrolDelay is 0 but angle > 2
            {
                tank.HandleTurretRotation((Vector2)tank.aimTuret.transform.position + randomDirection);
            }
        }
    }

}
