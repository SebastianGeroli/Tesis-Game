using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class Menu_UI : MonoBehaviour
{
    public Button btn;
    bool encender = false;

    // Start is called before the first frame update
    void Start()
    {
        //Image luz = GetComponent<Image>();
       
        
        EventTrigger trigger = GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerEnter;
        entry.callback.AddListener((data) => { OnPointerEnter((PointerEventData)data); });
        trigger.triggers.Add(entry);
       
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    public void OnPointerEnter(PointerEventData data)
    {
        if (encender == false)
        {
            encender = true;

        }
        Debug.Log("OnPointerEnter called.");
       
    }
  
}
