using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchBox   : MonoBehaviour

{

    [SerializeField]
    private Color activeColor = Color.red;

    [SerializeField]
    private Color inactiveColor = Color.gray;
    private RotateBox selectedProduct;


    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            

            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hitObject;
            if (Physics.Raycast(ray, out hitObject))
            {
                GameObject[] products = GameObject.FindGameObjectsWithTag("Product");
                /*
                foreach (GameObject product in products)
                {
                    RotateBox p1 = product.GetComponent<RotateBox>();
                    if (product.RotateMe)
                    {
                        selectedProduct = product;
                    }
                }
                */
                Debug.Log("Touchh");
                Debug.Log(hitObject.transform.tag);
                if (hitObject.transform.tag == "Product")
                {

                    if (!GameObject.ReferenceEquals(hitObject.collider.GetComponent<RotateBox>(), selectedProduct))
                    {
                        if (selectedProduct != null)
                        {
                            selectedProduct.GetComponent<MeshRenderer>().material.color = Color.cyan;
                            selectedProduct.ChangeBool();
                        }

                        selectedProduct = hitObject.collider.GetComponent<RotateBox>();
                        Debug.Log("if passed");
                        hitObject.collider.GetComponent<MeshRenderer>().material.color = Color.red;
                        hitObject.collider.GetComponent<RotateBox>().ChangeBool();

                    }

                    


                }
            }

        }
    }

  
}
