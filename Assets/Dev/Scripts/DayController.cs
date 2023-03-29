using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayController : MonoBehaviour
{
    [SerializeField] GameObject sun;

    private void Start()
    {
        LeanTween.rotateAround(sun, -Vector3.right, 360, 10);
    }
}
