using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Highlights : MonoBehaviour
{
    [SerializeField]
    Camera cam;

    public LayerMask mask;

    Material originalMaterial;
    GameObject lastHighlightedObject;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        // Draw Ray
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 100f;
        mousePos = cam.ScreenToWorldPoint(mousePos);
        Debug.DrawRay(transform.position, mousePos - transform.position, Color.blue);


            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100, mask))
        {

            //Debug.Log(hit.transform.name);
            //GameObject hitObject = hit.collider.gameObject;

            //hit.transform.GetComponent<Renderer>().material.color = Color.red;



            GameObject hitObject = hit.collider.gameObject;

            // Si on touche un nouvel objet
            if (hitObject != lastHighlightedObject)
            {
                // Réinitialiser la couleur de l'objet précédent
                if (lastHighlightedObject != null)
                {
                    Renderer lastRenderer = lastHighlightedObject.GetComponent<Renderer>();
                    if (lastRenderer != null && originalMaterial != null)
                    {
                        lastRenderer.material = originalMaterial;
                    }
                }

                // Mettre à jour l'objet en surbrillance
                Renderer hitRenderer = hitObject.GetComponent<Renderer>();
                if (hitRenderer != null)
                {
                    originalMaterial = hitRenderer.material;
                    Material highlightMaterial = new Material(originalMaterial);
                    highlightMaterial.color = Color.red;
                    hitRenderer.material = highlightMaterial;
                }

                lastHighlightedObject = hitObject;
            }
        }
        else 
        {
            // Si aucun objet n'est touché, réinitialiser l'objet précédent
            if (lastHighlightedObject != null)
            {
                Renderer lastRenderer = lastHighlightedObject.GetComponent<Renderer>();
                if (lastRenderer != null && originalMaterial != null)
                {
                    lastRenderer.material = originalMaterial;
                }
                lastHighlightedObject = null;
                originalMaterial = null;
            }
        }
        
    }
}