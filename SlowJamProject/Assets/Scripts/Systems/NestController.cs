using System;
using UnityEngine;

public class NestController : MonoBehaviour
{
    private ScoreHandler _scoreHandler;

    private void Awake()
    {
        _scoreHandler = FindFirstObjectByType<ScoreHandler>();
    }

    private void CritterDelivered(int critterValue)
    {
        _scoreHandler.AddToScore(critterValue);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.GetComponent<PlayerController>())
        {
            Critter currentCritter = other.GetComponentInChildren<Critter>();
            CritterDelivered(currentCritter.PointValue);
            other.GetComponent<PlayerController>().StopCarryingCritter();
        }
    }
}
