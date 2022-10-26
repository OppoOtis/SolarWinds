using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitPosition : MonoBehaviour
{
    public PlanetPhysics planetPhysics;
    public GameObject planetInteractable;

    public float pitch;
    public float yaw;
    public float distance;

    private void Update()
    {
        UpdateOrbitPosition();
    }

    private void UpdateOrbitPosition()
    {
        Vector3 centerVector = transform.position;
        distance = Vector3.Distance(planetInteractable.transform.position, transform.position);
        Vector3 side1 = new Vector3(distance, 0, 0) - transform.position;
        Vector3 side2 = transform.position - new Vector3(planetInteractable.transform.position.x, 0, planetInteractable.transform.position.z);
        yaw = Vector3.Angle(side1, side2);
    }


}
