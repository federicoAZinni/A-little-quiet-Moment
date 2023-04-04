using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bottle : Tools
{
    private void Awake()
    {
        initPos = transform.localPosition;
    }
    public override void OnPointerDown(PointerEventData eventData)
    {
        if (!taken) { Player.INS.toolActual = this; taken = true; img.raycastTarget = false; }
    }
    public override void OnPointerClick(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public override void Action()
    {
        LeanTween.delayedCall(1.2f, () => {
            
        });
    }
}
