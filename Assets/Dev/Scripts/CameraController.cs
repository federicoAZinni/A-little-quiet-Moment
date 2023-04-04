using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Animator anim;
    bool cam;

    public static CameraController INS;
    private void Awake()
    {
        INS = this;
    }
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void CamStartGame()
    {
        anim.Play("Cam1");
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Q))
        //{
        //    if (cam) { anim.Play("Cam1"); LeanTween.rotateAround(Player.INS.chicaImg, Vector3.right, -20, 0.5f); }
        //    else { anim.Play("Cam2"); LeanTween.rotateAround(Player.INS.chicaImg, Vector3.right, 20, 0.5f); }
        //    cam = !cam;
        //}
    }
}
