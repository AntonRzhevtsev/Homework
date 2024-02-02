using System;
using UnityEngine;

[Serializable]
public class RunningStateConfig
{
    [SerializeField, Range(0, 10)] private float _runSpeed;
    [SerializeField, Range(0, 20)] private float _sprintSpeed;
    [SerializeField, Range(0, 5)] private float _walkSpeed;

    public float RunSpeed => _runSpeed;
    public float SprintSpeed => _sprintSpeed; 
    public float WalkSpeed => _walkSpeed;  
}
