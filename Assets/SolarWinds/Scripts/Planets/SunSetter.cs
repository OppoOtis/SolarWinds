using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunSetter : MonoBehaviour
{
    public float distancePlayerToStarPivot;
    public float distanceStarToStarPivot;
    public float thresholdDistance;

    public GameObject player;
    public GameObject sunSetterDistance;
    public GameObject star;
    public GameObject starPivot;

    public float startingSize;
    public bool updateOnce = true;

    public void Awake()
    {
        startingSize = star.transform.localScale.x;
    }

    private void Update()
    {
        float size = thresholdDistance/(player.transform.position - starPivot.transform.position).magnitude;
        Debug.Log(size);
        player.transform.LookAt(starPivot.transform.position);
        sunSetterDistance.transform.localPosition = new Vector3(0, 0, thresholdDistance);
        distancePlayerToStarPivot = Vector3.Distance(player.transform.position, starPivot.transform.position);
        distanceStarToStarPivot = Vector3.Distance(star.transform.position, starPivot.transform.position);
        if(distancePlayerToStarPivot > thresholdDistance)
        {
            star.transform.position = sunSetterDistance.transform.position;
            star.transform.localScale = new Vector3(startingSize * size, startingSize * size, startingSize * size);
            updateOnce = true;
        }
        else
        {
            if (updateOnce)
            {
                star.transform.localScale = new Vector3(startingSize, startingSize, startingSize);
                star.transform.localPosition = Vector3.zero;
                updateOnce = false;
            }
        }
    }
}
