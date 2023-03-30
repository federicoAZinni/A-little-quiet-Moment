using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DocumentTask : MonoBehaviour,IPointerDownHandler
{
    public GameObject approved;

    void Start()
    {
        StartAnimTask();
    }
    public void StartAnimTask()
    {
        LeanTween.moveLocalX(gameObject, 0, 1).setEaseOutBack();
    }
    
    public void EndAnimTask()
    {
        LeanTween.moveLocalX(gameObject, -1501, 1).setEaseOutBack().setOnComplete(_=> TaskManager.INS.NextTask());
    }

    public void Action()
    {
        if (Player.INS.toolActual.toolType != ToolsType.Seal) { Player.INS.toolActual.Restart(); return; }
        approved.SetActive(true);
        LeanTween.delayedCall(1, _ => EndAnimTask());
        Player.INS.toolActual.Restart();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Action();
    }
}
