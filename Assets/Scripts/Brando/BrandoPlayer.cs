using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrandoPlayer : BasePlayerController, IAimable, IMoveable, IAttackable
{
    public float velocity = 4;
    [SerializeField] GameObject objectInvocation;
    [SerializeField] Transform referencesParentInvocation;
    public Vector2 Position
    {
        get
        {
            return _aimPosition;
        }

        set
        {
            _aimPosition = value;

            //Debug.Log("Aim from " + this.name);
        }
    }

    protected override void Awake()
    {
        base.Awake();

        Debug.Log("Child Awake");
    }

    protected override void Start()
    {
        base.Start();

        Debug.Log("Child Start");
    }

    public void Move(Vector2 direction)
    {
        
        if (direction != Vector2.zero)
        {
            myRigidBody.velocity = new Vector3(direction.x,myRigidBody.velocity.y, direction.y)  * velocity;
        }
        else
        {
            myRigidBody.velocity = Vector2.zero;
        }   
    }

    public void Attack(Vector2 position)
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(position.x,position.y,0));

        if (Physics.Raycast(ray, out RaycastHit info))
        {
            Vector3 intantationPoint = info.point;
            Instantiate(objectInvocation, intantationPoint, Quaternion.identity, referencesParentInvocation);
        }
    }
}
