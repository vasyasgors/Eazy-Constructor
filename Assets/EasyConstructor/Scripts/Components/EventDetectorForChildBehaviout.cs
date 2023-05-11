using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDetectorForChildBehaviout : MonoBehaviour 
{
	private Behaviour[] behaviours;
    private bool hasContainsMouseObjectEvents = true;
    private object objectBelowCursor;

    private void Update()
    {
        InvokeMouseObjectEvents();
    }
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

    void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < behaviours.Length; i++)
            if (behaviours[i] != null)
                behaviours[i].OnTriggerEnter(other);
    }

    void OnTriggerExit(Collider other)
    {
        for (int i = 0; i < behaviours.Length; i++)
            if (behaviours[i] != null)
                behaviours[i].OnTriggerExit(other);
    }

    void OnTriggerStay(Collider other)
    {
        for (int i = 0; i < behaviours.Length; i++)
            if (behaviours[i] != null)
                behaviours[i].OnTriggerStay(other);
    }


    void OnCollisionEnter(Collision other)
    {
        for (int i = 0; i < behaviours.Length; i++)
            if (behaviours[i] != null)
                behaviours[i].OnCollisionEnter(other);
    }

    void OnCollisionExit(Collision other)
    {
        for (int i = 0; i < behaviours.Length; i++)
            if (behaviours[i] != null)
                behaviours[i].OnCollisionExit(other);
    }

    void OnCollisionStay(Collision other)
    {
        for (int i = 0; i < behaviours.Length; i++)
            if (behaviours[i] != null)
                behaviours[i].OnCollisionStay(other);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        for (int i = 0; i < behaviours.Length; i++)
            if (behaviours[i] != null)
                behaviours[i].OnTriggerEnter2D(other);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        for (int i = 0; i < behaviours.Length; i++)
            if (behaviours[i] != null)
                behaviours[i].OnTriggerExit2D(other);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        for (int i = 0; i < behaviours.Length; i++)
            if (behaviours[i] != null)
                behaviours[i].OnTriggerStay2D(other);
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        for (int i = 0; i < behaviours.Length; i++)
            if (behaviours[i] != null)
                behaviours[i].OnCollisionEnter2D(other);
    }

    void OnCollisionExit2D(Collision2D other)
    {
        for (int i = 0; i < behaviours.Length; i++)
            if (behaviours[i] != null)
                behaviours[i].OnCollisionExit2D(other);
    }

    void OnCollisionStay2D(Collision2D other)
    {
        for (int i = 0; i < behaviours.Length; i++)
            if (behaviours[i] != null)
                behaviours[i].OnCollisionStay2D(other);
    }









}
