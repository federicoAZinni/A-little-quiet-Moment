using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimFinal : MonoBehaviour
{

    [SerializeField] GameObject[] imgs;

    [SerializeField] GameObject[] all;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audiCLip;

    private void OnEnable()
    {
        LeanTween.delayedCall(1f, () => {
            foreach (var item in all)
            {
            item.SetActive(false);
         }
        });
        LeanTween.delayedCall(2f, () => {
            audioSource.clip = audiCLip;
            audioSource.Play();
            LeanTween.moveY(imgs[0],Screen.height/2, 1).setEaseOutBack();
            LeanTween.delayedCall(2.5f, () => {
                LeanTween.moveX(imgs[1], Screen.width / 2, 1).setEaseOutBack();
                LeanTween.delayedCall(3f, () =>
                {
                    LeanTween.moveX(imgs[2], Screen.width / 2, 1).setEaseOutBack();
                    LeanTween.delayedCall(3f, () =>
                    {
                        LeanTween.moveY(imgs[3], Screen.height / 2, 1).setEaseOutBack();
                        LeanTween.delayedCall(6f, () =>
                        {
                            Menu.INS.LastFade();
                            //fin;
                        });
                    });
                });
            });
        });
    }
}


//LeanTween.moveY(imgs[2], 0, 1).setEaseOutBack();
//LeanTween.delayedCall(5f, () =>
//{
//    Menu.INS.LastFade();
//    //fin;
//});