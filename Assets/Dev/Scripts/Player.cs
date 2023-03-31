using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player INS;

    public Tools toolActual;
    public GameObject chicaImg;
    private void Awake()
    {
        INS = this;   
    }

    private void Update()
    {
        if (toolActual != null)
        {
            toolActual.transform.position = Input.mousePosition;
        }

    }
}
