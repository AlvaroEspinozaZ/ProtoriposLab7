using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExample : BasePlayerController, IAimable, IMoveable, IAttackable
{
    public float velocity=4;
    public Vector2 Position
    {
        get
        {
            return _aimPosition;
        }

        set
        {
            _aimPosition = value;

            Debug.Log("Aim from " + this.name);
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

        if(direction != Vector2.zero){
            myRigidBody.velocity = direction * velocity;
        }
        else
        {
            myRigidBody.velocity = Vector2.zero;
        }
        //Debug.Log("Move from " + this.name);
    }

    public void Attack(Vector2 position)
    {
        Debug.Log("Attack from " + this.name);
    }
}
