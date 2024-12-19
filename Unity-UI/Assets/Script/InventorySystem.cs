using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class InventorySystem : MonoBehaviour
{
    //public Text leftHandText;  // Texte du panneau de la main gauche
    //public Text rightHandText; // Texte du panneau de la main droite

    private GameObject selectedObject = null; // L'objet actuellement sélectionné
    private GameObject ObjectinLeftHand = null;
    private GameObject ObjectinRightHand = null;
    public LayerMask mask;

    [SerializeField]
    private TMPro.TextMeshProUGUI leftHandText;

    [SerializeField]
    private TMPro.TextMeshProUGUI rightHandText;

    public bool isemptyRight;
    public bool isemptyLeft;

    public GameObject RightImage;
    public GameObject LeftImage;


    public GameObject leftHandPrefab; // Préfabriqué pour l'objet dans la main gauche
    public GameObject rightHandPrefab; // Préfabriqué pour l'objet dans la main droite


    public Vector3 cursorPos;

    [SerializeField]
    public float maxdistance;

    private void Start()
    {
        isemptyRight = true;
        isemptyLeft = true;
    }


    void Update()
    {
        // Vérifie si un objet a été cliqué
        //if (Input.GetMouseButtonDown(0)) // Bouton gauche de la souris
        //{
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, maxdistance, mask))
            {
                if (hit.collider != null)
                {
                    selectedObject = hit.collider.gameObject; // Sélectionne l'objet
                }
            }

        if (Physics.Raycast(ray, out hit, maxdistance))
        {
            if (hit.collider != null)
            {
                cursorPos = hit.point;
                //Debug.Log(cursorPos);
            }
        }
        //}

        // Gestion des entrées clavier
        if (selectedObject != null)
        {
            if (Input.GetKeyDown(KeyCode.Q) && isemptyLeft == true) // A pour main gauche
            {
                AddToLeftHand(selectedObject);
                //leftHandPrefab = selectedObject;
                //Destroy(selectedObject);
                ObjectinLeftHand = selectedObject;
                selectedObject.gameObject.SetActive(false);
                selectedObject = null; // Désélectionne l'objet
                
            }
            else if (Input.GetKeyDown(KeyCode.E) && isemptyRight == true) // D pour main droite
            {
                AddToRightHand(selectedObject);
                //rightHandPrefab = selectedObject;
                //Destroy(selectedObject);
                ObjectinRightHand = selectedObject;
                selectedObject.gameObject.SetActive(false);
                selectedObject = null; // Désélectionne l'objet
                
            }
        }

        // Création d'objet à partir des mains
        if (Input.GetKeyDown(KeyCode.F) && isemptyLeft == false) // A pour créer à partir de la main gauche
        {
            CreateObjectFromLeftHand();
            
            //isemptyLeft = true;
        }
        else if (Input.GetKeyDown(KeyCode.C) && isemptyRight == false) // D pour créer à partir de la main droite
        {
            CreateObjectFromRightHand();

            //isemptyRight = true;
        }


        if (isemptyLeft == false)
        {
            LeftImage.SetActive(false);
        }
        else
        {
            LeftImage.SetActive(true);
        }


        if (isemptyRight == false)
        {
            RightImage.SetActive(false);
        }
        else
        {
            RightImage.SetActive(true);
        }

    }

    void AddToLeftHand(GameObject obj)
    {
        leftHandText.text = $"Main Gauche: {obj.name}"; // Met à jour le panneau gauche
        leftHandPrefab = obj; // Stocke le prefab de l'objet
        isemptyLeft = false;
    }

    void AddToRightHand(GameObject obj)
    {
        rightHandText.text = $"Main Droite: {obj.name}"; // Met à jour le panneau droit
        rightHandPrefab = obj; // Stocke le prefab de l'objet
        isemptyRight = false;
    }

    void CreateObjectFromLeftHand()
    {
        if (leftHandPrefab != null)
        {
            // Instancier l'objet au niveau du curseur
            Vector3 spawnPosition = GetCursorWorldPosition();
            //Instantiate(leftHandPrefab, spawnPosition, Quaternion.identity);

            isemptyLeft = true; // Libère la main gauche
            leftHandText.text = "."; // Met à jour l'UI
            leftHandPrefab = null; // Réinitialise la main gauche

            ObjectinLeftHand.transform.position = cursorPos;
            ObjectinLeftHand.gameObject.SetActive(true);
        }
    }

    void CreateObjectFromRightHand()
    {
        if (rightHandPrefab != null)
        {
            // Instancier l'objet au niveau du curseur
            Vector3 spawnPosition = GetCursorWorldPosition();
            //Instantiate(rightHandPrefab, spawnPosition, Quaternion.identity);

            isemptyRight = true; // Libère la main droite
            rightHandText.text = "."; // Met à jour l'UI
            rightHandPrefab = null; // Réinitialise la main droite

            ObjectinRightHand.transform.position = cursorPos;
            ObjectinRightHand.gameObject.SetActive(true);
        }
    }

    Vector3 GetCursorWorldPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 100, mask))
        {
            return hit.point; // Retourne la position dans le monde
        }
        return Vector3.zero; // Par défaut, retourne (0, 0, 0)
    }
}
