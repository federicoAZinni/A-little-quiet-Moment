using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player INS;

    public Tools toolActual;
    public GameObject chicaImg;
    public AudioSource audioSources;
    public AudioClip[] suspiros;
    private void Awake()
    {
        INS = this; 
    }

    public void RandomSuspiro()
    {
        audioSources.PlayOneShot(suspiros[Random.Range(0,suspiros.Length)]);
    }

    private void Update()
    {
        if (toolActual != null)
        {
            toolActual.transform.position = Input.mousePosition;
        }

    }
}
