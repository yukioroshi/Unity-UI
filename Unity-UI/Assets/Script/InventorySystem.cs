using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class InventorySystem : MonoBehaviour
{
    //public Text leftHandText;  // Texte du panneau de la main gauche
    //public Text rightHandText; // Texte du panneau de la main droite

    private GameObject selectedObject = null; // L'objet actuellement s�lectionn�
    public LayerMask mask;

    [SerializeField]
    private TMPro.TextMeshProUGUI leftHandText;

    [SerializeField]
    private TMPro.TextMeshProUGUI rightHandText;


    void Update()
    {
        // V�rifie si un objet a �t� cliqu�
        //if (Input.GetMouseButtonDown(0)) // Bouton gauche de la souris
        //{
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100, mask))
            {
                if (hit.collider != null)
                {
                    selectedObject = hit.collider.gameObject; // S�lectionne l'objet
                    hit.transform.GetComponent<Renderer>().material.color = Color.red;
                }
            }
        //}

        // Gestion des entr�es clavier
        if (selectedObject != null)
        {
            if (Input.GetKeyDown(KeyCode.Q)) // A pour main gauche
            {
                AddToLeftHand(selectedObject.name);
                Destroy(selectedObject);
                selectedObject = null; // D�s�lectionne l'objet
                
            }
            else if (Input.GetKeyDown(KeyCode.E)) // D pour main droite
            {
                AddToRightHand(selectedObject.name);
                Destroy(selectedObject);
                selectedObject = null; // D�s�lectionne l'objet
                
            }
        }
    }

    void AddToLeftHand(string objectName)
    {
        leftHandText.text = $"Main Gauche: {objectName}"; // Met � jour le panneau gauche
    }

    void AddToRightHand(string objectName)
    {
        rightHandText.text = $"Main Droite: {objectName}"; // Met � jour le panneau droit
    }
}
