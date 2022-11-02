using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour
{
    public GameObject Track1;
    public GameObject Track2;
    public GameObject Track3;

    private GameObject[] tracks = new GameObject[3];
    private GameObject currentTrack;

    private float[] trackVolumes;
    private int currentChannel = 0;
    private void Awake()
    {
        tracks[0] = Track1;
        tracks[1] = Track2;
        tracks[2] = Track3;
        
        currentTrack = Instantiate(tracks[Random.Range(0, tracks.Length)]);

        trackVolumes = new float[currentTrack.transform.childCount];

        foreach (AudioSource channel in currentTrack.transform.GetComponentsInChildren<AudioSource>())
        {
            Debug.Log(currentChannel);
            trackVolumes[currentChannel] = channel.volume;
            channel.volume = 0.0f;
            currentChannel++;
        }
        currentChannel = 0;
    }

    private void Start()
    {
        currentTrack.transform.GetChild(currentChannel).GetComponent<AudioSource>().volume = trackVolumes[currentChannel];
        currentChannel++;
    }


    public void AddChannel()
    {
        currentTrack.transform.GetChild(Mathf.Min(currentChannel, currentTrack.transform.childCount - 1))
            .GetComponent<AudioSource>().volume = trackVolumes[Mathf.Min(currentChannel, currentTrack.transform.childCount - 1)];
        currentChannel++;
    }

    public void RemoveChannel()
    {
        currentTrack.transform.GetChild(Mathf.Min(currentChannel, currentTrack.transform.childCount - 1))
            .GetComponent<AudioSource>().volume = trackVolumes[Mathf.Min(currentChannel, currentTrack.transform.childCount - 1)];
        currentChannel++;
    }
}
