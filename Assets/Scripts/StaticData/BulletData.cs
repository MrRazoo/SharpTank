using UnityEngine;
[CreateAssetMenu(fileName = "newBulletData" , menuName = "Data/BulletData")]
public class BulletData : ScriptableObject
{
    public float speed = 10;
    public int damage = 5;
    public float maxDistance = 10;


}
