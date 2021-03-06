using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class RotateBox : MonoBehaviour
{
    float xSpeed = 0.0f;
    float ySpeed = 0.0f;
    float zSpeed = 0.0f;
    public bool RotateMe = false;

    [SerializeField]
    private TextMeshPro nameText;

    [SerializeField]
    private TextMeshPro dateText;

    private TMP_InputField nameInput;

    private DateTime expiration;// = DateTime.Now;
    public string DateFormat = "dd-MM-yyyy";

    public int idProduct;

    public ProductModel productModel = new ProductModel();

    [SerializeField]
    private string nameTextString;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(DateTime.Now.AddDays(UnityEngine.Random.Range(0, 25)));
        if (!File.Exists(Application.persistentDataPath + "/gamesave.save"))
        {
            expiration = DateTime.Now.AddDays(UnityEngine.Random.Range(0, 30));
            Debug.Log("File not exists!!!");
        }
        this.GetComponent<MeshRenderer>().material.color = state();
        SetExpirationDate(expiration);
        productModel.idProduct = idProduct;
        productModel.name = nameText.text;

    }

    // Update is called once per frame
    void Update()
    {/*
        if (RotateMe)
        {
            ySpeed = 40;
        }
        else
        {
            ySpeed = 0;
        }

        transform.Rotate(
            xSpeed * Time.deltaTime,
            ySpeed * Time.deltaTime,
            zSpeed * Time.deltaTime
            );*/
    }

    public void ChangeBool()
    {
        RotateMe = !RotateMe;
    }

    public void SetText(string textInput)
    {
        nameText.SetText(textInput);
        productModel.name = textInput;
    }

    public void SetExpirationDate(DateTime expirationDate)
    {
        dateText.SetText(expirationDate.ToString(DateFormat));
        expiration = expirationDate;
        this.GetComponent<MeshRenderer>().material.color = state();
        productModel.expirationDate = expirationDate;
    }

    public void SetDefaultColor()
    {
        this.GetComponent<MeshRenderer>().material.color = state();
    }
    public Color state()
    {
        TimeSpan remainderDays = expiration.Subtract(DateTime.Now);
        if (remainderDays.Days < 1)
        {
            return Color.red;
        }
        else if (remainderDays.Days >= 1 && remainderDays.Days < 4)
        {
            return new Color(1.0f, 0.505f, 0.121f);
        }
        else if (remainderDays.Days >= 4 && remainderDays.Days < 10)
        {
            return Color.yellow;
        }
        else
        {
            return Color.green;
        }
    }

    public void UpdateNameInput()
    {     
        // Buscar el UIManager, tomar el name input y obtener el inputField
        nameInput = GameObject.FindWithTag("UIManager").GetComponent<UIManager>().nameInput.GetComponentInChildren<TMP_InputField>();
        nameInput.text = nameText.text;
    }

    public void SetModel(ProductModel productModel)
    {
        // Cargar el nuevo modelo
        this.productModel = productModel;
        // Settear el texto del modelo
        nameText.SetText(this.productModel.name);
        // Settear la fecha de expiracion en el render
        dateText.SetText(productModel.expirationDate.ToString(DateFormat));
        // Asignar la nueva fecha
        expiration = productModel.expirationDate;
        // Actualizar color
        this.GetComponent<MeshRenderer>().material.color = state();
    }
}
