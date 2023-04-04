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
        LeanTween.moveLocalX(transform.parent.gameObject, -150, 1).setEaseOutBack();
    }
    public void EndAnimTask()
    {
        LeanTween.moveLocalX(transform.parent.gameObject, -1500, 1).setEaseOutBack();
        TaskManager.INS.TaskCompleted();
        listBox.Clear();
        finish = false;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (boxActual != null)
        {
            listBox.Remove(boxActual);
            listBox.Add(boxActual);
            boxActual.inBox = true;
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
        if (listBox.Count >=5 && !finish) {
            finish = true;
            LeanTween.delayedCall(1, () => {
            EndAnimTask(); 
            
            LeanTween.delayedCall(1, () => {
                foreach (Box item in listBox)
                {
                    Destroy(gameObject);
                    item.Restar();
                }
            });
        });}
    }
}
