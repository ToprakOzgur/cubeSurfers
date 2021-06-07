using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputController : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public static event Action<Vector2> OnDragEvent = delegate { };
    public static event Action<Vector2> OnDragEndedEvent = delegate { };


    #region UI Events
    public void OnDrag(PointerEventData eventData)
    {
        OnDragEvent(eventData.delta);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        OnDragEndedEvent(eventData.delta);
    }
    #endregion

}

