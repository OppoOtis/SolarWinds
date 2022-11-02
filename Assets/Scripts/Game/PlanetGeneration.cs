
using System.Collections.Generic;
using UnityEngine;

public class PlanetGeneration : MonoBehaviour
{

    public GameObject prefab;
    
    public GameObject vader;
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
        //Setup mesh
        SetupMesh(target);
        //Setup Physics TODO
        SetupPhysics();
        //Setup music TODO
    }

    void SetupPhysics() //TODO
    {
        
    }
    
    void SetupMesh(GameObject g)
    {
        CelestialBodyGenerator jennyTheGenny = g.GetComponent<CelestialBodyGenerator>();
        jennyTheGenny.OnShapeSettingChanged();
        CopyAllSciptObjs(g);
        jennyTheGenny.OnShapeSettingChanged();
    }

    void CopyAllSciptObjs(GameObject g)
    {
        ScriptableObject[] ss = g.GetComponents<ScriptableObject>();
        for (int i = 0; i < ss.Length; i++)
        {
            ss[i] = Instantiate(ss[i]);
        }
    }
}
