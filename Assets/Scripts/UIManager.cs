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

    DbModel data = new DbModel();

    [SerializeField]
    private GameObject saveText;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.OnMainMenu += ActivateMainMenu;
        GameManager.instance.OnItemsMenu += ActivateItemsMenu;
        GameManager.instance.OnARPosition += ActivateARPosition;

        // Cargar datos del juego
        if(File.Exists(Application.persistentDataPath + "/gamesave.save"))
        {
            Debug.Log(Application.persistentDataPath + "/gamesave.save");

            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
            data = (DbModel)bf.Deserialize(file);
            file.Close();

            GameObject[] products = GameObject.FindGameObjectsWithTag("Product");
            //RotateBox[] rotateBoxes = new RotateBox[products.Length];
            // Para cada producto en data, buscar el correspondiente en los rotate box
            for (int i = 0; i < data.products.Count; i++)
            {
                foreach(GameObject product in products)
                {
                    // Comparar id de db con id de escena
                    if (product.GetComponent<RotateBox>().idProduct == data.products[i].idProduct)
                    {
                        product.GetComponent<RotateBox>().SetModel(data.products[i]);
                    }
                }
                
            }


        }
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

        StartCoroutine(waiter());
    }


    IEnumerator waiter()
    {
        saveText.SetActive(true);

        yield return new WaitForSeconds(3);

        saveText.SetActive(false);
    }

   
}
