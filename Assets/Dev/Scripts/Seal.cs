using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Seal : Tools
{
    [SerializeField] AnimationCurve animcurve;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip clip;
    private void Awake()
    {
        toolType = ToolsType.Seal;
        initPos = transform.localPosition;
    }
    public override void OnPointerDown(PointerEventData eventData)
    {
        if (!taken) { Player.INS.toolActual = this; taken = true; img.raycastTarget = false;  }
    }

    public override void Action()
    {
        LeanTween.moveLocal(gameObject, new Vector2(40,-80), 0.5f).setEase(animcurve).setOnComplete(()=> { audioSource.PlayOneShot(clip); });
        Player.INS.toolActual = null;
        LeanTween.delayedCall(0.5f, _ => base.Restart(gameObject));
    }
}
