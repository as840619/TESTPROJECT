using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] Transform _idle;
    [SerializeField] Vector3 _offset;
    void Look()
    {
        transform.position = _idle.position + _offset;
        transform.LookAt(_idle.position);
    }

    private void Update()
    {
        Look();
    }
}
