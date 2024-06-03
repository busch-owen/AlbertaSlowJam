using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    GameObject _playerObject;

    void Awake()
    {
        _playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = _playerObject.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = _playerObject.transform.position;
        transform.rotation = _playerObject.transform.rotation;
    }
}
