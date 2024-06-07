using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Critter : MonoBehaviour
{
    [field: SerializeField] public int PointValue { get; private set; }

    private Rigidbody _rb;

    private float _xVel, _zVel;

    [SerializeField] private Vector2 velocityRange;
    [SerializeField] private float randomizeRate;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(RandomizeVelocity), 0, randomizeRate);
    }

    private void RandomizeVelocity()
    {
        _xVel = Random.Range(velocityRange.x, velocityRange.y);
        _zVel = Random.Range(velocityRange.x, velocityRange.y);
        if(_rb.isKinematic) return;
        _rb.linearVelocity = new Vector3(_xVel, _rb.linearVelocity.y, _zVel);
    }
}
