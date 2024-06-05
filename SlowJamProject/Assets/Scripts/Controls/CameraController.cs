using System;
using Unity.Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private CinemachineFollow _cinemachineFollow;

    [SerializeField] private float lerpSpeed;

    [SerializeField] private Vector3 followPosition, topDownPosition;

    private void Awake()
    {
        _cinemachineFollow = GetComponent<CinemachineFollow>();
    }

    public void SwitchToTopDownView()
    {
        _cinemachineFollow.FollowOffset = Vector3.Lerp(_cinemachineFollow.FollowOffset, topDownPosition, lerpSpeed * Time.fixedDeltaTime);
    }

    public void SwitchToFollowView()
    {
        _cinemachineFollow.FollowOffset = followPosition;
    }
}
