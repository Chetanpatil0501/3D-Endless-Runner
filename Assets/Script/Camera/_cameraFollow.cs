using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _cameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    public float smoothSpeed = 0.125f;
    [SerializeField] float Distance;

    private void FixedUpdate()
    {
        Vector3 desiredPosition = new Vector3(transform.position.x, transform.position.y, target.position.z - Distance);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
