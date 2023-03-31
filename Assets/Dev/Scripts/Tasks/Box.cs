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

    private void Awake()
    {
        img = GetComponent<Image>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        onMouse = true;
        img.raycastTarget = false;
        boxTask.boxActual = this;
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0)) { onMouse = false; img.raycastTarget = true; boxTask.boxActual = null; }

        if (onMouse) transform.position = Input.mousePosition;
    }
}

