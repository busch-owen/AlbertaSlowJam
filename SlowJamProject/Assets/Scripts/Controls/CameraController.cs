using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform followTarget;
    [SerializeField] private float followOffset;
    [SerializeField] private float followHeight;
    [SerializeField] private float followLerpSpeed;
    [SerializeField] private float lookAtLerpSpeed;

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, followTarget.forward * followOffset,
            followLerpSpeed * Time.deltaTime);
        
        var lookDirection = followTarget.position - transform.position;
        lookDirection.Normalize();

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookDirection), lookAtLerpSpeed * Time.deltaTime);
    }
}
