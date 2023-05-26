using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Система долбанутая, не работает события физики нормально
public class EventDetectorForChildBehaviout : MonoBehaviour 
{
	private Behaviour[] behaviours;
    private bool hasContainsMouseObjectEvents = true;
    private object objectBelowCursor;


    // Перенести в один метод
    private void InvokeMouseObjectEvents()
    {

        
        RaycastHit hit;

        RaycastHit2D hit2D = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, float.MaxValue) == true ||
            hit2D.collider != null)
        {

            GameObject rootObject = null;
            if (hit.collider != null)
                rootObject = hit.collider.transform.root.gameObject;

            if (hit2D.collider != null)
                rootObject = hit2D.collider.transform.root.gameObject;

            if (rootObject == null) return;

            EventDetectorForChildBehaviout rootEventDetector = rootObject.GetComponent<EventDetectorForChildBehaviout>();

          

            if (rootEventDetector != null)
            {
                if (rootEventDetector != this) return;

                if (objectBelowCursor == null)
                {
                    objectBelowCursor = rootEventDetector;

                    for (int i = 0; i < behaviours.Length; i++)
                        if (behaviours[i] != null)
                            behaviours[i].MouseObjectEnter();
                }



                if (Input.GetMouseButtonDown(0) == true)
                {
                    for (int i = 0; i < behaviours.Length; i++)
                        if (behaviours[i] != null)
                            behaviours[i].MouseObjectDown();

                }

            }
        }
        else
        {
            if (objectBelowCursor != null)
            {
                for (int i = 0; i < behaviours.Length; i++)
                    if (behaviours[i] != null)
                        behaviours[i].MouseObjectExit();


            }

            objectBelowCursor = null;
        }
        
    }

    void Awake () 
	{
		behaviours = GetComponentsInChildren<Behaviour>();
	}

    void Start()
    {
        for (int i = 0; i < behaviours.Length; i++)
            if (behaviours[i] != null)
                behaviours[i].InvokeStart();
    }


    void Update()
    {

        InvokeMouseObjectEvents();

        for (int i = 0; i < behaviours.Length; i++)
            if (behaviours[i] != null)
                behaviours[i].InvokeUpdate();

    }

    void OnDestroy()
    {
        for (int i = 0; i < behaviours.Length; i++)
            if (behaviours[i] != null)
                behaviours[i].InvokeOnDestroy();
    }


    void OnTriggerEnter(Collider other)
    {
        Debug.Log("sdf");
        for (int i = 0; i < behaviours.Length; i++)
            if (behaviours[i] != null)
                behaviours[i].InvokeOnTriggerEnter(other);
    }

    void OnTriggerExit(Collider other)
    {
        for (int i = 0; i < behaviours.Length; i++)
            if (behaviours[i] != null)
                behaviours[i].InvokeOnTriggerExit(other);
    }

    void OnTriggerStay(Collider other)
    {
        for (int i = 0; i < behaviours.Length; i++)
            if (behaviours[i] != null)
                behaviours[i].InvokeOnTriggerStay(other);
    }


    void OnCollisionEnter(Collision other)
    {
        for (int i = 0; i < behaviours.Length; i++)
            if (behaviours[i] != null)
                behaviours[i].InvokeOnCollisionEnter(other);
    }

    void OnCollisionExit(Collision other)
    {
        for (int i = 0; i < behaviours.Length; i++)
            if (behaviours[i] != null)
                behaviours[i].InvokeOnCollisionExit(other);
    }

    void OnCollisionStay(Collision other)
    {
        for (int i = 0; i < behaviours.Length; i++)
            if (behaviours[i] != null)
                behaviours[i].InvokeOnCollisionStay(other);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        for (int i = 0; i < behaviours.Length; i++)
            if (behaviours[i] != null)
                behaviours[i].InvokeOnTriggerEnter2D(other);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        for (int i = 0; i < behaviours.Length; i++)
            if (behaviours[i] != null)
                behaviours[i].InvokeOnTriggerExit2D(other);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        for (int i = 0; i < behaviours.Length; i++)
            if (behaviours[i] != null)
                behaviours[i].InvokeOnTriggerStay2D(other);
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        for (int i = 0; i < behaviours.Length; i++)
            if (behaviours[i] != null)
                behaviours[i].InvokeOnCollisionEnter2D(other);
    }

    void OnCollisionExit2D(Collision2D other)
    {
        for (int i = 0; i < behaviours.Length; i++)
            if (behaviours[i] != null)
                behaviours[i].InvokeOnCollisionExit2D(other);
    }

    void OnCollisionStay2D(Collision2D other)
    {
        for (int i = 0; i < behaviours.Length; i++)
            if (behaviours[i] != null)
                behaviours[i].InvokeOnCollisionStay2D(other);
    }









}
