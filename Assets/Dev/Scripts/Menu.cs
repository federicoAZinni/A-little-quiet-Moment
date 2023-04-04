using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Image imgFadeInOut;
    public GameObject buttons;
    public GameObject Animinit;
    public GameObject AnimFinal;
    public GameObject taskPanel;
    public GameObject credits;
    public GameObject fin;
    public GameObject slider;

    public static Menu INS;
    private void Awake()
    {
        INS = this;
    }

    private void Start()
    {
        FadeInOut();
        AudioManager.ins.PlayMenu();
    }
    public void StartGame()
    {
        FadeInOut();
        LeanTween.delayedCall(1, () => { 
            buttons.SetActive(false);
            Animinit.SetActive(true);
            AudioManager.ins.PlayComic();
        });
        LeanTween.delayedCall(10f, () => {
            FadeInOut();
            LeanTween.delayedCall(1f, () => {
                Animinit.SetActive(false);
                LeanTween.delayedCall(1f, () => {
                    CameraController.INS.CamStartGame();
                    LeanTween.delayedCall(1.5f, () => {
                        LeanTween.moveY(taskPanel, 0, 0.5f).setEaseOutQuad();
                        TaskManager.INS.StartGame();
                        slider.SetActive(true);
                    });
                });
            });
        });
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
    }
    public void FadeInOut()
    {
        imgFadeInOut.CrossFadeAlpha(1, 1f, false);
        LeanTween.delayedCall(2, () => { imgFadeInOut.CrossFadeAlpha(0, 2.0f, false); });
    }
    public void LastFade()
    {
        imgFadeInOut.CrossFadeAlpha(1, 1f, false);
        LeanTween.delayedCall(1, _ => fin.SetActive(true));
    }

    public void Credits()
    {
        buttons.SetActive(false);
        credits.SetActive(true);
    }
    public void Buttons()
    {
        credits.SetActive(false);
        buttons.SetActive(true);
    }
}
