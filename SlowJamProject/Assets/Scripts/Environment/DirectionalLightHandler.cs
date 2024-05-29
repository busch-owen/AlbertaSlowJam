using System;
using UnityEngine;

public class DirectionalLightHandler : MonoBehaviour
{
    private Transform _lightTrans;
    [SerializeField] private float rotationAngle;

    private TimeHandler _timeHandler;
    private float _rotationAmount;

    [SerializeField] private float rotationFrequency;

    private void Awake()
    {
        _lightTrans = transform;
        _timeHandler = FindFirstObjectByType<TimeHandler>();
        _rotationAmount = 360f / (_timeHandler.TimeStep * 24f) ;
    }

    public void StartDayCycle()
    {
        InvokeRepeating(nameof(AddToRotation), 0, rotationFrequency);
    }

    public void StopDayCycle()
    {
        CancelInvoke(nameof(AddToRotation));
    }
    
    private void AddToRotation()
    {
        //rotationAngle *= rotationFrequency;
        rotationAngle += _rotationAmount * rotationFrequency;
        
        if (rotationAngle % 360 == 0) rotationAngle = 0;
        
        _lightTrans.localRotation = Quaternion.AngleAxis(rotationAngle, Vector3.right);
    }
}
