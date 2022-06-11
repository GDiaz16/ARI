using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ProductManager : MonoBehaviour
{
    private RotateBox selectedProduct;

    public event Action OnselectProduct;

    public static ProductManager instance;

   [SerializeField]
    private TMP_InputField nameInput;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void selectProduct()
    {
        OnselectProduct?.Invoke();
        GameObject[] products = GameObject.FindGameObjectsWithTag("Product");

        /*
        foreach(GameObject product in products){
            if (product.RotateMe)
            {
                selectedProduct = product;
            }
        }*/
    }
}
