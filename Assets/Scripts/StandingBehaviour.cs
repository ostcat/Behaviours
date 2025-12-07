using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandingBehaviour : IIdleBehaviour
{
    private Rotator _rotator;
    private Enemy _enemy;
    private float _rotationSpeed;

    public StandingBehaviour(Rotator rotator, float rotationSpeed)
    {
        _rotator = rotator;
        _rotationSpeed = rotationSpeed;
    }

    public void FixedProcess()
    {
        
    }

    public void Process()
    {
        Debug.Log(_rotator != null);
        _rotator.ProcessRotateAroundY(_rotationSpeed);
    }
}
