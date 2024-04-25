using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEmbestida : BasePlayerController, IAimable, IMoveable, IAttackable
{
    public float velocity = 4;
    public float velocityChrage = 12;
    public LayerMask myLayer;
    public Vector2 Position
    {
        get
        {
            return _aimPosition;
        }

        set
        {
            _aimPosition = value;

        }
    }

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
    }

    public void Move(Vector2 direction)
    {

        if (direction != Vector2.zero)
        {
            Vector3 tmo = new Vector3(direction.x, 0, direction.y);
            myRigidBody.velocity = tmo * velocity;
        }
        else
        {
            myRigidBody.velocity = Vector2.zero;
        }
    }

    public void Attack(Vector2 position)
    {
        
        Vector3 positionMouse = new Vector3(position.x , position.y, 0 );

        Debug.Log(position);
        Debug.Log(Camera.main.ScreenPointToRay(new Vector3(position.x, position.y, 0)).direction);

        Ray ray = Camera.main.ScreenPointToRay(new Vector3(position.x, position.y, 0));

        RaycastHit hit;

        if (Physics.Raycast(ray, out RaycastHit info))
        {
            Debug.Log(info.point);
            Vector3 intantationPoint = info.point;
            Vector3 directionToCharge = new Vector3(intantationPoint.x- transform.position.x, 0, intantationPoint.z - transform.position.z);

            myRigidBody.velocity = directionToCharge.normalized * velocityChrage;
            Debug.Log("Direction " + directionToCharge.normalized);
            if ((intantationPoint - transform.position ).magnitude < 2f)
            {
                myRigidBody.velocity = Vector3.zero;
                Debug.Log((intantationPoint - transform.position ).magnitude);
            }
        }
        
    }
}