using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimInit : MonoBehaviour
{
    [SerializeField] GameObject[] imgs;


    private void OnEnable()
    {
        LeanTween.delayedCall(1.5f, () => { 
        LeanTween.moveLocalX(imgs[0], -360, 1).setEaseOutBack();
        LeanTween.delayedCall(1.5f, () => {
            LeanTween.moveLocalY(imgs[1], 267f, 1).setEaseOutBack();
            LeanTween.delayedCall(2f, () => {
                LeanTween.moveLocalY(imgs[2], -246f, 1).setEaseOutBack();
            });
        });
        });
    }
}
