using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Control : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    private Vector2 ilkVector, sonVector;
    private float aci;
    [SerializeField]
    public GameObject asd;

    public void OnDrag(PointerEventData eventData)
    {
        sonVector = eventData.position;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        ilkVector = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        aci = Vector2.Angle(ilkVector,sonVector);
        //asd.transform.rotation = Quaternion.Euler(0, 0, aci);
        //Debug.Log(sonVector + " " + ilkVector + "ACI " + aci);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
