using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Box : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] Image img; 
    bool onMouse;
    [SerializeField] BoxTask boxTask;
    Vector3 initPos;
    public bool inBox;

    private void Awake()
    {
        img = GetComponent<Image>();
        initPos = transform.localPosition;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        onMouse = true;
        img.raycastTarget = false;
        boxTask.boxActual = this;
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0)) { onMouse = false; img.raycastTarget = true; boxTask.boxActual = null;
            if (inBox) img.raycastTarget = false;
        }

        if (onMouse) transform.position = Input.mousePosition;
    }

    public void Restar()
    {
        transform.localPosition = initPos;
    }
}

