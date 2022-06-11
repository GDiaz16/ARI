using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductManager : MonoBehaviour
{
    private RotateBox selectedProduct;

    [SerializeField]
    private TextMeshPro text;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*
    private selectedProduct()
    {
        RotateBox[] products = GameObject.FindGameObjectsWithTag("Product");

        foreach(RotateBox product in products){
            if (product.RotateMe)
            {
                selectedProduct = product;
            }
        }
    }*/
}
