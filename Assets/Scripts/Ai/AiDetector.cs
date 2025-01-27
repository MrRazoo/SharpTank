using System.Collections;
using UnityEngine;

public class AiDetector : MonoBehaviour
{
    [SerializeField]
    private readonly float viewRadius = 8f;
    [SerializeField]
    private float DetectionCheckDelay = 0.1f;
    [SerializeField]
    private LayerMask playerLayerMask;
    [SerializeField]
    private LayerMask visibilityLayer;
    [SerializeField]
    private Transform target = null;
    [field: SerializeField]
    public bool IsTargetVisible {get; private set; }
    public Transform Target
    {
        get { return target ;}
        private set 
        { 
            target = value ;
            IsTargetVisible = false;
            // her other logic...
        }
    }

    private void Start()
    {
        StartCoroutine(DetectionCoroutine()); // once Run this Coroutine.
    }

    private void Update()
    {
        if(Target != null)
        {
            IsTargetVisible =  checkTargetVisible();
        }
    }

    private void DetectTarget()
    {
        if(target == null)
        {
            findIsTargetInRange();
        }
        else if(target != null)
        {
            findIsTargetOutOfRange();
        }
    }

    private void findIsTargetInRange()
    {
        Collider2D collider = Physics2D.OverlapCircle(transform.position, viewRadius, playerLayerMask);
        if(collider != null) // something lies in Range
        {
            Target = collider.transform; // locate Player
        }
    }

    private void findIsTargetOutOfRange()
    {
        if(Target == null || Vector2.Distance(transform.position, Target.position) > viewRadius + 0.5f)
        {
            Target = null;
        }
    }

    private bool checkTargetVisible()
    {
        // Here visibility layer include all visibles to enemy like obstacle, different players with same PlayerLayer.
        var result = Physics2D.Raycast(transform.position, Target.position-transform.position, viewRadius, visibilityLayer); 
        if(result.collider != null)
        {         // palyers (4 layer => 010 000) & if result hit is obstacle (layer 3 => 001 000) equals is 0 because hit with layer which is not Players.
            return (playerLayerMask & 1 << result.collider.gameObject.layer) != 0; // if any Player Layer Detected 
        }
        return false;
    }

    IEnumerator DetectionCoroutine()
    {
        yield return new WaitForSeconds(DetectionCheckDelay);
        DetectTarget();
        StartCoroutine(DetectionCoroutine()); // loop It
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, viewRadius);
        if(target != null) Gizmos.DrawLine(transform.position, target.position);   
    }



}
