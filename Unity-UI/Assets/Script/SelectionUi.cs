using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SelectionUi : MonoBehaviour
{

    public Button LeftHand, RightHand, Object;
        

    public GameObject ObjectInterface;


    // Start is called before the first frame update
    void Start()
    {
        ObjectInterface.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


     public void OpenUi()
    {
        ObjectInterface.SetActive(true);
    }

    public void SelectLeftHand()
    {

    }
    public void SelectRightHand()
    {

    }
}
