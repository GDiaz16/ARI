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

    [SerializeField]
    private UIManager uiManager;

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began && uiManager.canTouch())
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
                    // True si se selecciona una caja diferente a la actual
                    if (!GameObject.ReferenceEquals(hitObject.collider.GetComponent<RotateBox>(), selectedProduct))
                    {
                        // Cambiar el cubo anterior al color por defecto
                        if (selectedProduct != null)
                        {
                            selectedProduct.SetDefaultColor();
                            selectedProduct.ChangeBool();
                        }

                        // Cambiar el cubo seleccionado al nuevo color
                        selectedProduct = hitObject.collider.GetComponent<RotateBox>();
                        hitObject.collider.GetComponent<MeshRenderer>().material.color = Color.blue;
                        // Asignar como activado
                        hitObject.collider.GetComponent<RotateBox>().ChangeBool();
                        // Actualizar input
                        hitObject.collider.GetComponent<RotateBox>().UpdateNameInput();

                    }

                    


                }
            }

        }
    }

  
}
