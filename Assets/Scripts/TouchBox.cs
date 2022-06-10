using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchBox   : MonoBehaviour

{

    private PlacementObject[] placedObjects;

    [SerializeField]
    private Color activeColor = Color.red;

    [SerializeField]
    private Color inactiveColor = Color.gray;


    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            

            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hitObject;
            if (Physics.Raycast(ray, out hitObject))
            {
                Debug.Log("Touchh");
                Debug.Log(hitObject.transform.tag);
                if (hitObject.transform.tag == "Box")
                {
                    Debug.Log("if passed");
                    hitObject.collider.GetComponent<MeshRenderer>().material.color = Color.red;
                    hitObject.collider.GetComponent<RotateBox>().ChangeBool();
                }
            }

        }
    }

    private void ChangeSelectedObject(PlacementObject selected)
    {
        foreach (PlacementObject current in placedObjects)
        {
            MeshRenderer meshRenderer = current.GetComponent<MeshRenderer>();
            if(selected != current)
            {
                current.IsSelected = false;
                meshRenderer.material.color = inactiveColor;
            }
            else
            {
                current.IsSelected = true;
                meshRenderer.material.color = activeColor;
            }
        }
    }
}
