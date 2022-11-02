using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetScaling : MonoBehaviour
{
    public GameObject planetMesh;
    public GameObject planetInteractable;
    public float distanceFromInteractable = 1;

    public bool setOffset;

    private void Update()
    {
        if (setOffset)
        {
            transform.position = new Vector3(planetInteractable.transform.position.x + distanceFromInteractable, planetInteractable.transform.position.y, planetInteractable.transform.position.z);
        }
        else
        {
            distanceFromInteractable = Vector3.Distance(planetInteractable.transform.position, transform.position);
            planetMesh.transform.localScale = new Vector3(distanceFromInteractable, distanceFromInteractable, distanceFromInteractable);
        }
    }

    public void SetOffsetOn()
    {
        setOffset = true;
    }

    public void SetOffsetOff()
    {
        setOffset = false;
    }
}
