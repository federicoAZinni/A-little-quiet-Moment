using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Seal : Tools
{

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
        LeanTween.moveLocalY(gameObject, 0, 0.2f);
        LeanTween.delayedCall(0.3f, _ => base.Restart(gameObject));
    }
}
