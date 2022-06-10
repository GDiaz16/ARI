using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject MainMenuCanvas;
    [SerializeField] private GameObject itemsMenuCanvas;
    [SerializeField] private GameObject ARPositionCanvas;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.OnMainMenu += ActivateMainMenu;
        GameManager.instance.OnItemsMenu += ActivateItemsMenu;
        GameManager.instance.OnARPosition += ActivateARPosition;


    }

    private void ActivateMainMenu(){
    }

    private void ActivateItemsMenu(){
        MainMenuCanvas.transform.GetChild(0).transform.DOScale(new Vector3(0,0,0), 0.3f);
    }

    private void ActivateARPosition(){}

   
}
