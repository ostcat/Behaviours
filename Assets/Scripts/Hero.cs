using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    private const string HorizontalAxisName = "Horizontal";
    private const string VerticalAxisName = "Vertical";
    private float _deadZone = 0.01f;
    private Mover _mover;
    private Rotator _rotator;
    private Vector3 _moveVector;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed = 500;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
        _rotator = GetComponent<Rotator>();
    }

    private void Update()
    {
        _moveVector = new Vector3(Input.GetAxisRaw(HorizontalAxisName), 0, Input.GetAxisRaw(VerticalAxisName));

        if (_moveVector.magnitude <= _deadZone)
        {
            return;
        }
        else
        {
            _mover.ProcessMoveTo(_moveVector, _speed);
            _rotator.ProcessRotateTo(_moveVector, _rotationSpeed);
        }
    }
}
