using System.Collections.Generic;
using UnityEngine;

public class PlanetGeneration : MonoBehaviour
{

    public GameObject prefab;
    public GameObject vader;
    public PlanetManager pm;
    void Update()
    {
        //Well this needs to be changed to a button or some shit, probably even out of update to a dedotated handler TODO
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GeneratePlanet(vader);
        }
    }

    void GeneratePlanet(GameObject parent)
    {
        //Instantiate
        GameObject target = Instantiate(prefab, Vector3.zero, Quaternion.identity, parent.transform);
        target.transform.localPosition = Vector3.zero;
        //Setup mesh
        SetupMesh(target);
        //Setup Physics TODO
        SetupPhysics(target);
        //Setup music TODO
        pm.AddPlanetToList(target);
    }

    void SetupPhysics(GameObject g) //TODO
    {
        PlanetPhysics pp = g.GetComponent<PlanetPhysics>();
        pp.distanceFromSun = pm.furthestPlanetDistance + 12f;
    }

    void SetupMesh(GameObject g)
    {
        CelestialBodyGenerator jennyTheGenny = g.GetComponent<PlanetPhysics>().planetMesh.GetComponent<CelestialBodyGenerator>();
        jennyTheGenny.OnShapeSettingChanged();
        //CopyAllSciptObjs(g);
        jennyTheGenny.OnShapeSettingChanged();
    }

    void CopyAllSciptObjs(GameObject g)
    {
        ScriptableObject[] ss = g.GetComponent<PlanetPhysics>().planetMesh.GetComponents<ScriptableObject>();
        for (int i = 0; i < ss.Length; i++)
        {
            ss[i] = Instantiate(ss[i]);
        }
    }
}
