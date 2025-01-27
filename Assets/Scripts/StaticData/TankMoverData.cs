using UnityEngine;
[CreateAssetMenu(fileName = "NewTankMoverData" , menuName = "Data/TankMovement")]
public class TankMoverData : ScriptableObject
{
    public float speed = 70f;
    public float rotationSpeed = 200f;
    public float acceleration = 70f;
    public float deceleration = 80f;
    
}
