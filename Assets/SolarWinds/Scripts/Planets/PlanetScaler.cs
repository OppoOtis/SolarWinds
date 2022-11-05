using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetScaler : MonoBehaviour
{
    public float startingStarScale;
    public GameObject starSystem;
    public float startingPlanetScale;
    public float scaleFactor;
    public GameObject pivot;

    private void Awake()
    {
        startingPlanetScale = transform.localScale.x;
    }

    public void ScalePlanets()
    {
        Debug.Log("test");
        float scaleFactor = starSystem.transform.localScale.x / startingStarScale;
        transform.localScale = new Vector3(startingPlanetScale * scaleFactor, startingPlanetScale * scaleFactor, startingPlanetScale * scaleFactor);
        //transform.position = pivot.transform.position;
    }
}
