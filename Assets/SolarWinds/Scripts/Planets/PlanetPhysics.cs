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
    public GameObject planetMesh;
    public GameObject planetInteractable;

    public bool dontMoveInteractable;

    public float orbitSpeed;
    [Range(0f, 360f)]
    public float orbitYaw = 0;
    [Range(0f, 360f)]
    public float orbitPitch = 0;

    public float rotationSpeed;
    [Range(-45f, 45f)]
    public float rotationPitch = 0;

    [Range(1f, 10f)]
    public float distanceFromSun = 5;

    private void Update()
    {
        orbitYawPivot.transform.localRotation = Quaternion.Euler(0, orbitYaw, 0);
        orbitPitchPivot.transform.localRotation = Quaternion.Euler(orbitPitch, 0, 0);
        if (gameObject.GetComponent<OrbitPosition>().isActiveAndEnabled == false)
        {
            orbitPivot.transform.Rotate(new Vector3(0, orbitSpeed, 0) * Time.deltaTime);
            dontMoveInteractable = false;
        }
        if (!dontMoveInteractable)
        {
            planetInteractable.transform.position = planetMesh.transform.position;
        }
        dontMoveInteractable = true;

        //Vector3 centerRotation = new Vector3(0, -orbitSpeed, 0,);
        centerPivot.transform.Rotate(new Vector3(0, -orbitSpeed, 0) * Time.deltaTime);
        centerPitchPivot.transform.localRotation = Quaternion.Euler(0, 0, rotationPitch);
        planetMesh.transform.Rotate(new Vector3(0, rotationSpeed, 0) * Time.deltaTime);

        centerPivot.transform.localPosition = new Vector3(0, 0, distanceFromSun);
    }
}
