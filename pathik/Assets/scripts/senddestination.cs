using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class senddestination : MonoBehaviour,IDragHandler,IEndDragHandler
{
    
    public Transform myplace;
    
    void start()
    {
       
      
    }
   

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = myplace.position;
    }


}
