using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public GameObject leftHand;
    public GameObject rightHand;

    public bool punching;
    public Vector3 oldLeftPosition;
    public Vector3 oldRightPosition;

    public int sceneToLoad = 0;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hands"))
        {
            punching = true;
        }
    }
    private void Update()
    {
        float leftSpeed = Vector3.Distance(oldLeftPosition, leftHand.transform.position);
        float rightSpeed = Vector3.Distance(oldRightPosition, rightHand.transform.position);
        if (punching)
        {
            if (leftSpeed >= 0.025f || rightSpeed >= 0.025f)
            {
                SceneManager.LoadScene(sceneToLoad);
            }
            punching = false;
        }
        oldLeftPosition = leftHand.transform.position;
        oldRightPosition = rightHand.transform.position;
    }
}
