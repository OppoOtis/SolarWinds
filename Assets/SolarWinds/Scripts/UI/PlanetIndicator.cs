using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetIndicator : MonoBehaviour
{
    public GameObject targetObject;
    public GameObject targetPlayer;

    void Update()
    {
        transform.position = targetObject.transform.position;
        transform.LookAt(targetPlayer.transform);
        transform.rotation = Quaternion.LookRotation(targetPlayer.transform.forward);
    }
}
