using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Pen : Tools
{
    [SerializeField] Animator anim;
    private void Awake()
    {
        initPos = transform.localPosition;
    }
    private void Start()
    {
        
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
        anim.enabled = true;
        anim.Play("PenAnim");
        LeanTween.delayedCall(1.2f, () => {
            anim.enabled = false;
            base.Restart(gameObject); 
        });
    }
}
