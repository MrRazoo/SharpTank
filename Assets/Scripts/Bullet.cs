using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    public BulletData bulletData;
    private TrailRenderer trailRenderer;

    // these values are imported from scriptable objects 
    // public float speed = 10;
    // public int damage = 5;
    // public float maxDistance = 10;

    private Vector2 startPosition;
    public UnityEvent OnHit = new UnityEvent();
    private float conquaredDis = 0;
    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        trailRenderer = GetComponent<TrailRenderer>();
    }

    public void Initialize(BulletData bData) // just tp get specific speed :)
    {
        this.bulletData = bData;
        startPosition = transform.position;
        rb.velocity = transform.up * this.bulletData.speed;
    }

    private void Update()
    {
        conquaredDis = Vector2.Distance(transform.position, startPosition);
        if(conquaredDis > bulletData.maxDistance)
        {
            DisableObject();
        }
    }

    private void DisableObject()
    {
        rb.velocity = Vector2.zero;
        gameObject.SetActive(false);
        trailRenderer.Clear();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        OnHit?.Invoke();
        var damageable = other.GetComponent<Damageable>();
        if(damageable != null)
        {
            damageable.Hit(bulletData.damage);
        } 
        DisableObject();
    }
}