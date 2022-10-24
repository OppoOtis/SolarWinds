using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetPhysics : MonoBehaviour
{
    public GameObject orbitYawPivot;
    public GameObject orbitPitchPivot;
    public GameObject orbitPivot;
    public GameObject centerPivot;
    public GameObject centerPitchPivot;

    public float orbitSpeed;
    [Range(-90f, 90f)]
    public float orbitYaw = 0;
    [Range(-90f, 90f)]
    public float orbitPitch = 0;

    public float rotationSpeed;
    [Range(-45f, 45f)]
    public float rotationPitch = 0;

    [Range(1f, 10f)]
    public float distanceFromSun = 5;

    private void Update()
    {
        orbitYawPivot.transform.localRotation = Quaternion.Euler(0, orbitYaw, 0);
        orbitPitchPivot.transform.localRotation = Quaternion.Euler(0, 0, orbitPitch);
        orbitPivot.transform.Rotate(new Vector3(0, orbitSpeed, 0) * Time.deltaTime);

        //Vector3 centerRotation = new Vector3(0, -orbitSpeed, 0,);
        centerPivot.transform.Rotate(new Vector3(0, -orbitSpeed, 0) * Time.deltaTime);
        centerPitchPivot.transform.localRotation = Quaternion.Euler(0, 0, rotationPitch);
        transform.Rotate(new Vector3(0, rotationSpeed, 0) * Time.deltaTime);

        centerPivot.transform.localPosition = new Vector3(distanceFromSun,0,0);
    }
}
