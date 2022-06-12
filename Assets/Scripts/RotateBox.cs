using System;
using System.Collections;
using System.Collections.Generic;
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

    private DateTime expiration = DateTime.Now;
    public string DateFormat = "dd-MM-yyyy";

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<MeshRenderer>().material.color = state();
        SetExpirationDate(expiration);

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
    }

    public void SetExpirationDate(DateTime expirationDate)
    {
       dateText.SetText(expirationDate.ToString(DateFormat));
       this.GetComponent<MeshRenderer>().material.color = state();

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
        // Buscar caja de texto de name
        

        // Buscar el UIManager, tomar el name input y obtener el inputField
        nameInput = GameObject.FindWithTag("UIManager").GetComponent<UIManager>().nameInput.GetComponentInChildren<TMP_InputField>();
        nameInput.text = nameText.text;

        if (nameInput != null)
        {
            
        }
    }
}
