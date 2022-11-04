using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlanetGeneration : MonoBehaviour
{
    public GameObject prefab;
    public GameObject vader;
    public PlanetManager pm;
    public GameObject star;

    public CelestialBodySettings[] body;
    public CelestialBodyShape[] shape;
    public CelestialBodyShading[] shading;

    public GameObject leftHand;
    public GameObject rightHand;

    public bool punchingStar;
    public Vector3 oldLeftPosition;
    public Vector3 oldRightPosition;

    public MusicManager MusicManager;

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Ziet collider");
        if (other.CompareTag("Hands"))
        {
            punchingStar = true;
        }
    }
    private void Update()
    {
        float leftSpeed = Vector3.Distance(oldLeftPosition, leftHand.transform.position);
        float rightSpeed = Vector3.Distance(oldRightPosition, rightHand.transform.position);
        if (punchingStar)
        {
            if(leftSpeed >= 0.025f || rightSpeed >= 0.025f)
            {
                GeneratePlanet(vader);
            }
            punchingStar = false;
        }
        oldLeftPosition = leftHand.transform.position;
        oldRightPosition = rightHand.transform.position;

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

    void SetupMesh(GameObject g)
    {
        CelestialBodyGenerator jennyTheGenny = g.GetComponent<PlanetPhysics>().planetInteractable.GetComponent<CelestialBodyGenerator>();
        jennyTheGenny.OnShapeSettingChanged();
        //CopyAllSciptObjs(g);
        //jennyTheGenny.OnShapeSettingChanged();
        int randPlanetSettings = Random.Range(0, body.Length);
        CelestialBodySettings newSettings = Instantiate(body[randPlanetSettings]);
        CelestialBodyShape newShape = Instantiate(shape[randPlanetSettings]);
        CelestialBodyShading newShading = Instantiate(shading[randPlanetSettings]);
        newSettings.shape = newShape;
        newSettings.shading = newShading;
        jennyTheGenny.body = newSettings;

        var prng = new System.Random();
        jennyTheGenny.body.shading.randomize = true;
        jennyTheGenny.body.shape.randomize = true;
        jennyTheGenny.body.shape.seed = prng.Next(-10000, 10000);
        jennyTheGenny.body.shading.seed = prng.Next(-10000, 10000);
        Regenerate(jennyTheGenny);

        MusicManager.AddChannel();
    }
    void Regenerate(CelestialBodyGenerator generator)
    {
        generator.OnShapeSettingChanged();
        generator.OnShadingNoiseSettingChanged();
        //EditorApplication.QueuePlayerLoopUpdate();
    }

    void SetupPhysics(GameObject g) //TODO
    {
        PlanetPhysics pp = g.GetComponent<PlanetPhysics>();
        pp.distanceFromSun = Random.Range(10, 50);
        pp.orbitSpeed = Random.Range(10, 500);
        pp.orbitYaw = Random.Range(0, 360);
        pp.orbitPitch = Random.Range(0, 360);
    }

    void CopyAllSciptObjs(GameObject g)
    {
        ScriptableObject[] ss = g.GetComponent<PlanetPhysics>().planetInteractable.GetComponents<ScriptableObject>();
        for (int i = 0; i < ss.Length; i++)
        {
            ss[i] = Instantiate(ss[i]);
        }
    }
}
