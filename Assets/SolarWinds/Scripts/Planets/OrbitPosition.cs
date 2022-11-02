using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitPosition : MonoBehaviour
{
    public PlanetPhysics planetPhysics;
    public GameObject planetInteractable;
    public GameObject centerPoint;
    public GameObject orbitPivot;

    public float pitch;
    public float yaw;
    public float distance;

    private void Update()
    {
        UpdateOrbitPosition();
    }

    private void UpdateOrbitPosition()
    {
        planetPhysics.dontMoveInteractable = true;
        Vector3 centerVector = transform.position;
        distance = Vector3.Distance(planetInteractable.transform.position, transform.position);
        planetPhysics.orbitYaw = centerPoint.transform.rotation.eulerAngles.y;
        planetPhysics.orbitPitch = centerPoint.transform.rotation.eulerAngles.x;
        planetPhysics.distanceFromSun = distance;
    }


}
