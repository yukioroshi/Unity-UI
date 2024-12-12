using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SelectionUi : MonoBehaviour
{

    public Button LeftHand, RightHand, Object;
        

    public GameObject ObjectInterface;


    public bool click;


    // Start is called before the first frame update
    void Start()
    {
        ObjectInterface.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (CompareTag("Pickable"))
        {
            click = true;
            Debug.Log(click);
        }

        if (click == true)
        {
            ObjectInterface.SetActive(true);
            click = false;
        }
    }

    public void OpenSelectionUi()
    {


    }

    public void SelectLeftHand()
    {

        ObjectInterface.SetActive(false);
    }
    public void SelectRightHand()
    {

        ObjectInterface.SetActive(false);
    }
}
