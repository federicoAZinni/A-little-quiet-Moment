using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DocumentTask : MonoBehaviour,IPointerDownHandler
{
    public GameObject approved;

   
    private void OnEnable()
    {
        StartAnimTask();
    }
    public void StartAnimTask()
    {
        LeanTween.moveLocalX(gameObject, 0, 1).setEaseOutBack();
    }
    
    public void EndAnimTask()
    {
        LeanTween.moveLocalX(gameObject, -1500, 1).setEaseOutBack().setOnComplete(_ => {approved.SetActive(false); Destroy(gameObject); });
    }

    public void Action()
    {
        if (Player.INS.toolActual == null) return;
        if (Player.INS.toolActual.toolType != ToolsType.Seal ) { Player.INS.toolActual.Restart(Player.INS.toolActual.gameObject); return; }
        Seal seal = (Seal)Player.INS.toolActual;
        seal.Action();
        LeanTween.delayedCall(0.5f, () => { approved.SetActive(true); });
        LeanTween.delayedCall(1, () => { EndAnimTask(); TaskManager.INS.TaskCompleted(); });
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Action();
    }
}
