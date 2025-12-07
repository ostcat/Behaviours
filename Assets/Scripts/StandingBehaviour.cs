using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandingBehaviour : IIdleBehaviour
{
    private Rotator _rotator;
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
        if (_rotator != null)
            _rotator.ProcessRotateAroundY(_rotationSpeed);
        else
            return;
    }
}
