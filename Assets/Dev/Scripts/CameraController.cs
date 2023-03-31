using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Animator anim;
    bool cam;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (cam) { anim.Play("Cam1"); LeanTween.rotateAround(Player.INS.chicaImg, Vector3.right, -20, 0.5f); }
            else { anim.Play("Cam2"); LeanTween.rotateAround(Player.INS.chicaImg, Vector3.right, 20, 0.5f); }
            cam = !cam;
        }
    }
}
