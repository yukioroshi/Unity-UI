using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conteneur : MonoBehaviour
{
    // Nom du layer à vérifier
    [SerializeField]
    private string pickableLayerName = "pickable";

    private GameObject targetObject;
    public bool hasCollided = false;

    private void OnCollisionEnter(Collision collision)
    {
        // Vérifie si l'objet en collision a le layer "Pickable"
        if (collision.gameObject.layer == LayerMask.NameToLayer(pickableLayerName))
        {
            // Transfert de position à l'objet en collision
            targetObject = collision.gameObject;
            targetObject.transform.position = transform.position;
            hasCollided = true;

            // Optionnel : Transférer également la rotation
            // targetObject.transform.rotation = transform.rotation;

            // Message de débogage
            Debug.Log($"{targetObject.name} a reçu la position de {gameObject.name}");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Vérifie si l'objet qui quitte la collision est le même objet cible
        if (collision.gameObject == targetObject)
        {
            targetObject = null;
            hasCollided = false;

            // Message de débogage
            Debug.Log($"{collision.gameObject.name} ne suit plus {gameObject.name}");
        }
    }


    private void Update()
    {
        // Si un objet cible est défini et qu'une collision est en cours, mettre à jour sa position
        if (hasCollided == true && targetObject != null)
        {
            targetObject.transform.position = transform.position;
            
        }
    }
}
