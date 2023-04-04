using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BabyUI : MonoBehaviour, IPointerDownHandler
{
    public Baby baby;
    public void Action()
    {
        if (Player.INS.toolActual == null) return;
        if (Player.INS.toolActual.toolType != ToolsType.Bottle) { Player.INS.toolActual.Restart(Player.INS.toolActual.gameObject); return; }
        baby.BabyChangeState(Baby.BabyState.Eating);
        Player.INS.toolActual.Restart(Player.INS.toolActual.gameObject);
        LeanTween.delayedCall(2, () => { gameObject.SetActive(false); });
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Action();
    }
}
