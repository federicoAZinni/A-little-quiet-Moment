using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BoxTask : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Box boxActual;
    [SerializeField] List<Box> listBox;
    bool finish;

    private void OnEnable()
    {
        StartAnimTask();
    }
    public void StartAnimTask()
    {
        LeanTween.moveLocalX(transform.parent.gameObject, 0, 1).setEaseOutBack();
    }
    public void EndAnimTask()
    {
        LeanTween.moveLocalX(transform.parent.gameObject, -1500, 1).setEaseOutBack();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (boxActual != null)
        {
            listBox.Remove(boxActual);
            listBox.Add(boxActual);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (boxActual != null){ 
            listBox.Remove(boxActual); 
        }
    }

    private void Update()
    {
        if (listBox.Count >=5 && !finish) { LeanTween.delayedCall(1, () => { EndAnimTask(); finish = true; });  }
    }
}
