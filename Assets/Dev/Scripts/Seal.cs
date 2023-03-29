using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Seal : Tools
{
    bool taken;
    [SerializeField] Image imgSeal;
    [SerializeField] Vector3 initPos;

    private void Awake()
    {
        toolType = ToolsType.Seal;
    }
    public override void OnPointerDown(PointerEventData eventData)
    {
        if (!taken) { Player.INS.toolActual = this; taken = true; imgSeal.raycastTarget = false;  }
    }

    public override void Restart()
    {
        taken = true; 
        imgSeal.raycastTarget = true;
        LeanTween.moveLocal(gameObject, initPos, 0.3f).setEaseOutSine();
        Player.INS.toolActual = null;
    }
}
