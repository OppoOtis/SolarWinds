using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetManager : MonoBehaviour
{
    public List<GameObject> planets;

    public GameObject furthestPlanet;
    public float furthestPlanetDistance;

    private void Start()
    {
        planets = new List<GameObject>();
    }
    public void AddPlanetToList(GameObject p)
    {
        planets.Add(p);
        UpdatePlanetInfo();
    }

    public void UpdatePlanetInfo()
    {
        furthestPlanetDistance = 0;
        for(int i = 0; i < planets.Count; i++)
        {
            if(planets[i].GetComponent<PlanetPhysics>().distanceFromSun > furthestPlanetDistance)
            {
                furthestPlanet = planets[i];
                furthestPlanetDistance = planets[i].GetComponent<PlanetPhysics>().distanceFromSun;
            }
        }
    }
}
