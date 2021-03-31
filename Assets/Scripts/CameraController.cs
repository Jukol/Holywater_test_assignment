using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject _target;

    private void Update()
    {
        transform.LookAt(_target.transform);
    }
}
