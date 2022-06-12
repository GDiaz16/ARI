using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject MainMenuCanvas;
    [SerializeField] private GameObject itemsMenuCanvas;
    [SerializeField] private GameObject ARPositionCanvas;

    [SerializeField]
    private GameObject datePicker;

    [SerializeField]
    public GameObject nameInput;
    private RotateBox selectedProduct;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.OnMainMenu += ActivateMainMenu;
        GameManager.instance.OnItemsMenu += ActivateItemsMenu;
        GameManager.instance.OnARPosition += ActivateARPosition;

        // Cargar datos del juego

    }

    private void ActivateMainMenu(){
    }

    private void ActivateItemsMenu(){
        MainMenuCanvas.transform.GetChild(0).transform.DOScale(new Vector3(0,0,0), 0.3f);
    }

    private void ActivateARPosition(){}


    public void ToggleCalendar()
    {
        datePicker.SetActive(!datePicker.activeSelf);
        if (nameInput.activeSelf)
        {
            nameInput.SetActive(!nameInput.activeSelf);
        }
    }

    public void ToggleInputName()
    { 
        nameInput.SetActive(!nameInput.activeSelf);
        if (datePicker.activeSelf)
        {
            datePicker.SetActive(!datePicker.activeSelf);
        }

    }

    public bool canTouch()
    {
        if(nameInput.activeSelf || datePicker.activeSelf)
        {
            return false;

        }
        else
        {
            return true;
        }
    }

    public void Save()
    {
        DbModel data = new DbModel();
        GameObject[] products = GameObject.FindGameObjectsWithTag("Product");
        foreach (GameObject product in products)
        {
            ProductModel productModel = product.GetComponent<RotateBox>().productModel;
            data.products.Add(productModel);
        }

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
        Debug.Log(Application.persistentDataPath + "/gamesave.save");
        bf.Serialize(file, data);
        file.Close();
    }

   
}
