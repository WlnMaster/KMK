using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    Transform target;
    Vector3 Velocity = Vector3.zero;
    [Range(0,1)]
    public float smoothTime;
    public Vector3 positionOffset;
    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("P").transform;
    }
    private void LateUpdate()
    {
        Vector3 targetPosition = target.position+positionOffset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref Velocity, smoothTime);   
    }


}
