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
    public PlanetManager planetManager;

    public bool dontMoveInteractable;
    public bool runOnce = true;

    public float timeValue;

    public float orbitSpeed;
    [Range(0f, 360f)]
    public float orbitYaw = 0;
    [Range(0f, 360f)]
    public float orbitPitch = 0;

    public float rotationSpeed;
    [Range(-45f, 45f)]
    public float rotationPitch = 0;

    public float distanceFromSun = 5;

    public float lerpSpeed = 0.5f;
    public bool customPlanet = false;
    public float customLerpSpeed = 1;

    private void Start()
    {
        orbitYawPivot.transform.localRotation = Quaternion.Euler(0, orbitYaw, 0);
        orbitPitchPivot.transform.localRotation = Quaternion.Euler(orbitPitch, 0, 0);
        centerPivot.transform.localPosition = new Vector3(0, 0, distanceFromSun);
    }
    private void Update()
    {
        timeValue = planetManager.timeValue;
        //float lerpSp = 1;
        if (customPlanet)
        {
            //lerpSp = customLerpSpeed;
        }
        if (runOnce)
        {
            orbitYawPivot.transform.localRotation = Quaternion.Euler(0, orbitYaw, 0);
            orbitPitchPivot.transform.localRotation = Quaternion.Euler(orbitPitch, 0, 0);
            centerPivot.transform.localPosition = new Vector3(0, 0, distanceFromSun);
            runOnce = false;
        }
        if (gameObject.GetComponent<OrbitPosition>().isActiveAndEnabled == false)
        {
            orbitPivot.transform.Rotate(new Vector3(0, (orbitSpeed/100) * timeValue, 0) * Time.deltaTime);
            dontMoveInteractable = false;
        }
        if (!dontMoveInteractable)
        {
            if (customPlanet)
            {
                if (lerpSpeed < 50f)
                {
                    lerpSpeed = 500f;
                }
                //planetInteractable.transform.position = Vector3.Lerp(planetInteractable.transform.position, planetMesh.transform.position, Time.deltaTime * (lerpSpeed * lerpSp) * timeV);
                planetInteractable.transform.position = Vector3.Lerp(planetInteractable.transform.position, planetMesh.transform.position, Time.deltaTime * lerpSpeed);
            }
            else
            {
                planetInteractable.transform.position = Vector3.Lerp(planetInteractable.transform.position, planetMesh.transform.position, Time.deltaTime * lerpSpeed * timeValue);
            }
        }
        else
        {
            orbitPivot.transform.localRotation = Quaternion.Euler(Vector3.zero);
            runOnce = true;
        }
        dontMoveInteractable = true;

        //Vector3 centerRotation = new Vector3(0, -orbitSpeed, 0,);
        //centerPivot.transform.Rotate(new Vector3(0, (-orbitSpeed/100) * timeValue, 0) * Time.deltaTime);
        //centerPitchPivot.transform.localRotation = Quaternion.Euler(0, 0, rotationPitch);
        //planetMesh.transform.Rotate(new Vector3(0, rotationSpeed/100, 0) * Time.deltaTime);
    }
}
