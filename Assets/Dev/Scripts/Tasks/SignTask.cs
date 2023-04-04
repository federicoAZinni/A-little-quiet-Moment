using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SignTask : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] Animator anim;
    [SerializeField] Animator animSign;
    Vector3 initPos;
     Vector3 rotPos;
    [SerializeField] Image sign;
    [SerializeField] Sprite firstImgSign;
    private void Start()
    {
        initPos = transform.localPosition;
        rotPos = transform.localEulerAngles;
    }

    private void OnEnable()
    {
        LeanTween.moveLocalX(transform.parent.gameObject, 0, 1).setEaseOutBack();
        LeanTween.delayedCall(1, () => {
            LeanTween.moveLocalY(transform.parent.gameObject, 100, 1);
            LeanTween.scale(transform.parent.gameObject, Vector2.one * 2.5f, 1).setEaseOutBack();
        });
        LeanTween.delayedCall(2.5f, () => {
            anim.Play("MailAnim");
        });
        LeanTween.delayedCall(3.5f, () => {
            AnimationDocument();
        });
    }

    void AnimationDocument()
    {
        LeanTween.moveLocalX(gameObject,-300,0.5f).setEaseOutBack().setOnComplete(()=> {
            transform.SetAsLastSibling();
            LeanTween.rotateLocal(gameObject, Vector3.zero, 0.5f);
            LeanTween.moveLocalX(gameObject, 20, 0.5f);
            LeanTween.scale(gameObject, Vector2.one * 1.3f,0.5f).setEaseOutBack();
        });
    }


    public void Action()
    {
        if (Player.INS.toolActual == null) return;
        if (Player.INS.toolActual.toolType != ToolsType.Pen) { Player.INS.toolActual.Restart(Player.INS.toolActual.gameObject); return; }
        Pen pen = (Pen)Player.INS.toolActual;
        pen.Action();
        animSign.gameObject.SetActive(true);
        animSign.Play("sign");
        animSign.transform.SetAsLastSibling();
        LeanTween.delayedCall(2, () => { EndAnimTask(); });
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Action();
    }

    public void EndAnimTask()
    {
        LeanTween.moveLocalX(transform.parent.gameObject, -1500, 1).setEaseOutBack().setOnComplete(()=> {
            transform.localPosition = initPos;
            transform.localEulerAngles = rotPos;
            transform.localScale = Vector3.one;
            sign.transform.localScale = Vector3.one;
            sign.sprite = firstImgSign;
            transform.SetAsFirstSibling();
            Destroy(transform.parent.gameObject);
            TaskManager.INS.TaskCompleted();
        });
        
    }
}
