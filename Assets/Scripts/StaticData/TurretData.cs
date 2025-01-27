using UnityEngine;


[CreateAssetMenu(fileName = "NewTurretData" , menuName = "Data/TurretData")]
public class TurretData : ScriptableObject
{
    public GameObject bulletPrefab;
    public float reloadDelay = 0.3f;
    public BulletData bulletData;
}
