using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBig : Enemy
{
    private List<Transform> _patrolPoints;
    private float _speed;
    private Mover _mover;
    private Rotator _rotator;
    private bool _isAgro;
   

    public Mover Mover => _mover;
    public Rotator Rotator => _rotator;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
        _rotator = GetComponent<Rotator>();
    }

    

}
