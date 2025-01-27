using UnityEngine;

public class TankController : MonoBehaviour
{

    public TankMover tankMover;
    public AimTurret aimTuret;
    private Turret[] turrets;
    private void Awake()
    {
        tankMover = GetComponentInChildren<TankMover>();
        aimTuret = GetComponentInChildren<AimTurret>();
        turrets = GetComponentsInChildren<Turret>();
    }



    public void HandleShoot()
    {
        foreach(var turret in turrets)
        {
            turret.TurretFired();
        }
    }

    public void HandleTankMovement(Vector2 MovementVector)
    {
        tankMover.MoveBody(MovementVector);
    }

    public void HandleTurretRotation(Vector2 pointerPosition)
    {
        aimTuret.aimer(pointerPosition);
    }




}


