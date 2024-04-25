using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : BasePlayerController, IAimable, IMoveable, IAttackable
{
    public float velocity = 4;
    [SerializeField] private Quaternion qx = Quaternion.identity;
    [SerializeField] private Quaternion qy = Quaternion.identity;
    [SerializeField] private Quaternion qz = Quaternion.identity;
    [SerializeField] private Quaternion r = Quaternion.identity;
    private float anguloSen;
    private float anguloCos;
    private float angulosY = 0;
    private float angulosX = 0;
    public float forceY = 2;
    public float forceX = 2;
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
        
        
        //angulosX = direction.y;
        if (direction != Vector2.zero)
        {
            angulosX = direction.y;
            angulosY = direction.x;
           
        }       
    }
    void Rotar()
    {
        angulosX +=(angulosX);
        anguloSen = Mathf.Sin(Mathf.Deg2Rad * angulosX * 0.5f);
        anguloCos = Mathf.Cos(Mathf.Deg2Rad * angulosX * 0.5f);
        qx.Set(anguloSen, 0, 0, anguloCos);
        Debug.Log(angulosX);

        angulosY += (angulosY);
        anguloSen = Mathf.Sin(Mathf.Deg2Rad * angulosY * 0.5f);
        anguloCos = Mathf.Cos(Mathf.Deg2Rad * angulosY * 0.5f);
        qy.Set(0, anguloSen, 0, anguloCos);
        Debug.Log(angulosY);


        r = qy * qx * qz;

        transform.rotation = r;

        angulosY += angulosY;
        angulosX += angulosX;
    }
    private void FixedUpdate()
    {
        Rotar();
    }
    public void Attack(Vector2 position)
    {
    }
}
