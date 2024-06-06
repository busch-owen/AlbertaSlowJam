using System;
using UnityEngine;

public class CritterSpawner : MonoBehaviour
{
    [SerializeField] private GameObject critterToSpawn;
    [SerializeField] private float spawnRate;
    [SerializeField] private int critterLimit;
    private GameObject[] _crittersSpawned;

    [SerializeField] private Vector3 spawnPosition;

    private void Awake()
    {
        _crittersSpawned = new GameObject[critterLimit - 1];
    }

    private void Start()
    {
        InvokeRepeating(nameof(SpawnCritters), 0, spawnRate);
    }

    private void SpawnCritters()
    {
        if (_crittersSpawned.Length < critterLimit)
        {
            for(var i = 0; i < _crittersSpawned.Length; i++)
            {
                if (_crittersSpawned[i]) return;
                var spawnedCritter = Instantiate(critterToSpawn, transform.position + spawnPosition, Quaternion.identity);
                _crittersSpawned[i] = spawnedCritter;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position + spawnPosition, 0.5f);
    }
}
