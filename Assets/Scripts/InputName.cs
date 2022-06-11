using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class InputName : MonoBehaviour
{
    private RotateBox selectedProduct;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] products = GameObject.FindGameObjectsWithTag("Product");
        foreach (GameObject product in products)
        {
            if (product.GetComponent<RotateBox>().RotateMe)
            {
                selectedProduct = product.GetComponent<RotateBox>();
            }
        }
    }

    public void OnEndEdit()
    {
        //Debug.Log(GetComponentInParent<TMP_InputField>().text);
        if (selectedProduct != null)
        {
            selectedProduct.SetText(GetComponentInParent<TMP_InputField>().text);
        }
    }
}
