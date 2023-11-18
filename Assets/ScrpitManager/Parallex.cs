using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallex : MonoBehaviour

{
    public Camera cam;
    public Transform followTarget;

    //starting positions for the parallex game object
    Vector2 startingPositions;

    //starting Z value for the parallex game object
    float startingZ;
    Vector2 canMoveSinceStart => (Vector2)cam.transform.position - startingPositions;


    float zDistanceFormTarget => transform.position.z - followTarget.transform.position.z;

    float ClippingPlane => (cam.transform.position.z + (zDistanceFormTarget > 0 ? cam.farClipPlane : cam.nearClipPlane));

    float parallexFactor => Mathf.Abs(zDistanceFormTarget) / ClippingPlane;




    // Start is called before the first frame update
    void Start()
    {
        startingPositions = transform.position;
        startingZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPositions = startingPositions + canMoveSinceStart * parallexFactor;
        transform.position = new Vector3(newPositions.x, newPositions.y, startingZ);
    }
}
