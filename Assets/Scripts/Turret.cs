using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(ObjectPool))] // means where this script exist it also will have Objectpool script
public class Turret : MonoBehaviour
{
    public TurretData turretData;
    public List<Transform> barrels; // this is just psition in List

    private bool canShoot = true;
    private Collider2D[] tankColliders; // i think this is parent Colliders of tank 
    private float currentDelay = 0;
    public UnityEvent OnShoot, OncantShoot;
    public UnityEvent<float> OnReloading;

    // these are required to make a pool(water like) for our Bullet

    private ObjectPool bulletPool;
    [SerializeField]
    private int bulletPoolCount = 4;

    private void Awake()
    {
        tankColliders = GetComponentsInParent<Collider2D>();
        bulletPool = GetComponent<ObjectPool>();
    }
    // here we just assign our pool GameObject and its Counts Just :)

    private void Start()
    {
        bulletPool.Initialize(turretData.bulletPrefab, bulletPoolCount); // here just we set our bulletPrefab and count of pool (Optional)
        OnReloading?.Invoke(currentDelay); // start reloading
    }


    private void FixedUpdate()
    {
        if(canShoot == false)
        {
            currentDelay -= Time.deltaTime;
            if(currentDelay <= 0) canShoot = true;
            OnReloading?.Invoke(currentDelay / turretData.reloadDelay); // update reloading
        }
    }

    public void TurretFired()
    {
        if(canShoot)
        {

            
            foreach(var barrel in barrels)
            {
                GameObject bullet = bulletPool.CreateObject();
                bullet.transform.position = barrel.position;
                bullet.transform.localRotation = barrel.rotation;
                bullet.GetComponent<Bullet>().Initialize(turretData.bulletData);// we give special bulletdata via turretData (bulletData may changed here Easily via Scri.Obj
                // like we have three bulletData with seperate speed 
                foreach(var collider in tankColliders)
                {
                    Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), collider);
                }
            }
            
            canShoot = false;
            currentDelay = turretData.reloadDelay;
            OnShoot?.Invoke(); // fired 
            OnReloading?.Invoke(currentDelay); // update reloading
        }
        else
        {
            OncantShoot?.Invoke();
        }
    }
}
