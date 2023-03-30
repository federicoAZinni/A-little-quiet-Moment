using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SignTask : MonoBehaviour, TaskGame
{
    [SerializeField] Animator anim;
    private void OnEnable()
    {
        LeanTween.moveLocalX(transform.parent.gameObject, 0, 1).setEaseOutBack();
        LeanTween.delayedCall(1, () => {
            LeanTween.moveLocalY(transform.parent.gameObject, 130, 1);
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
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        
    }
}
