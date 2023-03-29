using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tools : MonoBehaviour, IPointerClickHandler, IPointerDownHandler
{
    public ToolsType toolType;

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public virtual void Restart() { }
}
public enum ToolsType { Seal }
