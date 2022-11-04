using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

public class CustomInteractions : MonoBehaviour
{
    public InputActionProperty pinchLeftInputAction;
    public InputActionProperty gripLeftInputAction;
    public InputActionProperty pinchRightInputAction;
    public InputActionProperty gripRightInputAction;
    public InputActionProperty rightHandSnapTurnAction;

    public GameObject leftControler;
    public GameObject rightControler;

    public GameObject starSystem;

    public bool canScale;
    public float startingDistance;
    public Vector3 startingMidpointPosition;
    public float startingHeightPosition;
    public Vector3 startingScale;
    // Start is called before the first frame update
    void Start()
    {
        rightHandSnapTurnAction.EnableDirectAction();
    }

    // Update is called once per frame
    void Update()
    {
        float triggerLeftValue = pinchLeftInputAction.action.ReadValue<float>();
        float triggerRightValue = pinchRightInputAction.action.ReadValue<float>();
        Vector2 rightHandValue = rightHandSnapTurnAction.action.ReadValue<Vector2>();
        Debug.Log(rightHandValue);
        float gripLeftValue = gripLeftInputAction.action.ReadValue<float>();
        float gripRightValue = gripRightInputAction.action.ReadValue<float>();
        if(rightHandValue.x < -0.1f || rightHandValue.x > 0.1f)
        {
            starSystem.GetComponent<PlanetManager>().UpdateTime(rightHandValue.x);
        }
        if(triggerLeftValue > 0.95f && triggerRightValue > 0.95f)
        {
            leftControler.GetComponent<SphereCollider>().enabled = false;
            rightControler.GetComponent<SphereCollider>().enabled = false;
            /*if (gripLeftValue > 0.95f && gripRightValue > 0.95f)
            {
                ScaleSystem();
            }*/
            ScaleSystem();
        }
        else
        {
            leftControler.GetComponent<SphereCollider>().enabled = true;
            rightControler.GetComponent<SphereCollider>().enabled = true;
            canScale = false;
            int small = 0;
            if(starSystem.transform.localScale.x < 0.01f)
            {
                small = 2;
                starSystem.GetComponent<PlanetManager>().UpdateLOD(small);
            }
            else if(starSystem.transform.localScale.x < 0.1f)
            {
                small = 1;
                starSystem.GetComponent<PlanetManager>().UpdateLOD(small);
            }
            else
            {
                small = 0;
                starSystem.GetComponent<PlanetManager>().UpdateLOD(small);
            }
        }
    }

    public void ScaleSystem()
    {
        if(canScale == false)
        {
            startingDistance = Vector3.Distance(leftControler.transform.position, rightControler.transform.position);
            startingMidpointPosition = Vector3.Lerp(leftControler.transform.position, rightControler.transform.position, 0.5f);
            startingScale = starSystem.transform.localScale;
            startingHeightPosition = starSystem.transform.position.y;
            starSystem.GetComponent<PlanetManager>().updatedLOD = false;
            canScale = true;
        }
        float currentDistance = Vector3.Distance(leftControler.transform.position, rightControler.transform.position);
        Vector3 currentMidpointPosition = Vector3.Lerp(leftControler.transform.position, rightControler.transform.position, 0.5f);
        float newScaleValue = currentDistance / startingDistance;
        if(newScaleValue < 0.05f)
        {
            newScaleValue = 0.05f;
        }
        Vector3 finalScale =  new Vector3(startingScale.x * newScaleValue,startingScale.y * newScaleValue, startingScale.y * newScaleValue);
        ScaleAround(starSystem, startingMidpointPosition, finalScale);
        float distanceBetweenMidpoints = currentMidpointPosition.y - startingMidpointPosition.y;
        //distanceBetweenMidpoints = Mathf.Abs(distanceBetweenMidpoints);
        //starSystem.transform.position = new Vector3(starSystem.transform.position.x, startingHeightPosition + distanceBetweenMidpoints, starSystem.transform.position.z);
    }

    public void ScaleAround(GameObject target, Vector3 pivot, Vector3 newScale)
    {
        Vector3 A = target.transform.localPosition;
        Vector3 B = pivot;

        Vector3 C = A - B; // diff from object pivot to desired pivot/origin

        float RS = newScale.x / target.transform.localScale.x; // relataive scale factor

        // calc final position post-scale
        Vector3 FP = B + C * RS;

        // finally, actually perform the scale/translation
        target.transform.localScale = newScale;
        target.transform.localPosition = FP;
    }
}
