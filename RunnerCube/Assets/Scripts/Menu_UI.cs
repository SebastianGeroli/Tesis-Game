using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using DG.Tweening;

public class Menu_UI : MonoBehaviour
{
    public Button btn;
    public Sprite luz;
    public Sprite sinLuz;
    //Image myImage; 
    public bool encender = false;
    //Sequence seq = DOTween.Sequence();

    // Start is called before the first frame update
    void Start()
    {
           
        
        EventTrigger trigger = GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerEnter;
        entry.callback.AddListener((data) => { OnPointerEnter((PointerEventData)data); });
        trigger.triggers.Add(entry);

        EventTrigger trigger2 = GetComponent<EventTrigger>();
        EventTrigger.Entry entry2 = new EventTrigger.Entry();
        entry2.eventID = EventTriggerType.PointerExit;
        entry2.callback.AddListener((data) => { OnPointerExit((PointerEventData)data); });
        trigger2.triggers.Add(entry2);

       // myImage = GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    public void OnPointerEnter(PointerEventData data)
    {
        if (encender == false)
        {           
            btn.interactable = true;
            btn.image.overrideSprite = luz;
            btn.image.DOFade(0.6f, 0.5f);
            encender = true;
         }
       
       // Debug.Log("OnPointerEnter called.");
       
    }
    public void OnPointerExit(PointerEventData data)
    {
        if (encender == true)
        {
            btn.image.DOFade(1f, 1f);
            btn.image.overrideSprite = sinLuz;
            encender = false;
        }
        //Debug.Log("OnPointerExit called.");
    }

}
