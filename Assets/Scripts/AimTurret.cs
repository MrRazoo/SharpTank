using UnityEngine;

public class AimTurret : MonoBehaviour
{
    public float turretRotation;
    public void aimer(Vector2 pointerPosition)
    {
        var turretDirection = (Vector3)pointerPosition - transform.position; //  targeted position ... 
        var desiredAngle = Mathf.Atan2(turretDirection.y, turretDirection.x) * Mathf.Rad2Deg; // mathf.Atan calculates angle w.r.t positive x-axis
        var Rotationalstep = turretRotation * Time.deltaTime;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, desiredAngle), Rotationalstep); // takes two rotations one current and other target and 3rd is speed.
    }
}
