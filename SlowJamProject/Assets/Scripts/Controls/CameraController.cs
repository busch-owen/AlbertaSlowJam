using System;
using Unity.Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private CinemachineFollow _cinemachineFollow;

    [SerializeField] private Vector3 followPosition, topDownPosition;

    private void Awake()
    {
        _cinemachineFollow = GetComponent<CinemachineFollow>();
    }

    public void SwitchToTopDownView()
    {
        _cinemachineFollow.FollowOffset = topDownPosition;
    }

    public void SwitchToFollowView()
    {
        _cinemachineFollow.FollowOffset = followPosition;
    }
}
