using UnityEngine;
using UnityEngine.Events;

public class playerInput : MonoBehaviour
{
    public UnityEvent OnShoot = new UnityEvent(); 
    public UnityEvent<Vector2> OnMoveBody = new UnityEvent<Vector2>(); 
    public UnityEvent<Vector2> OnRotate = new UnityEvent<Vector2>(); 

    void FixedUpdate()
    {
        GetShoot();
        GetBodyMovement();
        GetTurretRotation();
    }
    public void GetShoot()
    {
        if(Input.GetMouseButtonDown(0))
        {
            OnShoot?.Invoke();
        }
    }

    public void GetTurretRotation()
    {
        OnRotate?.Invoke(mousePosition());
    }

    public void GetBodyMovement()
    {
        Vector2 movementVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        OnMoveBody?.Invoke(movementVector.normalized);
    }
    
    private Vector2 mousePosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane; // it keeps z index near pointer
        Vector2 _MousePos = Camera.main.ScreenToWorldPoint(mousePos);
        return _MousePos;
    }



}
