using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetManager : MonoBehaviour
{
    public List<GameObject> planets;
    public List<GameObject> customPlanets;

    public GameObject furthestPlanet;
    public float furthestPlanetDistance;
    public bool updatedLOD;
    public GameObject player;

    public float timeValue = 1;

    private void Start()
    {
        planets = new List<GameObject>();
        foreach (GameObject planet in customPlanets)
        {
            planet.GetComponent<PlanetPhysics>().timeValue = timeValue;
        }
    }

    public void UpdateTime(float value)
    {
        timeValue *= (1 + (value/100));
        if(timeValue < 0.001f)
        {
            timeValue = 0.001f;
        }
        foreach(GameObject planet in planets)
        {
            planet.GetComponent<PlanetPhysics>().timeValue = timeValue;
        }
        foreach (GameObject planet in customPlanets)
        {
            planet.GetComponent<PlanetPhysics>().timeValue = timeValue;
        }
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

    public void UpdateLOD(int small)
    {
        float distance = 10000;
        if (!updatedLOD)
        {
            foreach (GameObject planet in planets)
            {
                float planetDistance = Vector3.Distance(planet.GetComponent<PlanetPhysics>().planetInteractable.transform.position, player.transform.position);
                if (planetDistance < distance)
                {
                    distance = planetDistance;
                }
            }
            foreach (GameObject planet in planets){
                if (small == 2)
                {
                    planet.GetComponent<PlanetPhysics>().planetInteractable.GetComponent<CelestialBodyGenerator>().previewMode = CelestialBodyGenerator.PreviewMode.LOD2;
                }
                else if(small == 1)
                {
                    planet.GetComponent<PlanetPhysics>().planetInteractable.GetComponent<CelestialBodyGenerator>().previewMode = CelestialBodyGenerator.PreviewMode.LOD1;
                }
                else
                {
                    float currentDistance = Vector3.Distance(planet.GetComponent<PlanetPhysics>().planetInteractable.transform.position, player.transform.position);
                    if (currentDistance <= (distance + 0.01f))
                    {
                        planet.GetComponent<PlanetPhysics>().planetInteractable.GetComponent<CelestialBodyGenerator>().previewMode = CelestialBodyGenerator.PreviewMode.LOD0;
                    }
                    else
                    {
                        planet.GetComponent<PlanetPhysics>().planetInteractable.GetComponent<CelestialBodyGenerator>().previewMode = CelestialBodyGenerator.PreviewMode.LOD1;
                    }
                }
                planet.GetComponent<PlanetPhysics>().planetInteractable.GetComponent<CelestialBodyGenerator>().OnShapeSettingChanged();
            }
            updatedLOD = true;
        }
    }
}
