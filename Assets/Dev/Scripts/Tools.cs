using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Tools : MonoBehaviour, IPointerClickHandler, IPointerDownHandler
{
    public ToolsType toolType;
    public bool taken;
    public Vector3 initPos;
    public Image img;

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public virtual void Action(){ }

    public virtual void Restart(GameObject obj) { 

        Player.INS.toolActual = null;
        LeanTween.moveLocal(obj, initPos, 0.3f).setEaseOutSine();
        taken = false ;
        img.raycastTarget = true;
    }
}
public enum ToolsType { Seal,Pen }
