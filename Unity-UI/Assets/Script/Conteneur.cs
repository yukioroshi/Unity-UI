using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conteneur : MonoBehaviour
{
    // Nom du layer � v�rifier
    [SerializeField]
    private string pickableLayerName = "pickable";

    private GameObject targetObject;
    public bool hasCollided = false;

    private void OnCollisionEnter(Collision collision)
    {
        // V�rifie si l'objet en collision a le layer "Pickable"
        if (collision.gameObject.layer == LayerMask.NameToLayer(pickableLayerName))
        {
            // Transfert de position � l'objet en collision
            targetObject = collision.gameObject;
            targetObject.transform.position = transform.position;
            hasCollided = true;

            // Optionnel : Transf�rer �galement la rotation
            // targetObject.transform.rotation = transform.rotation;

            // Message de d�bogage
            Debug.Log($"{targetObject.name} a re�u la position de {gameObject.name}");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // V�rifie si l'objet qui quitte la collision est le m�me objet cible
        if (collision.gameObject == targetObject)
        {
            targetObject = null;
            hasCollided = false;

            // Message de d�bogage
            Debug.Log($"{collision.gameObject.name} ne suit plus {gameObject.name}");
        }
    }


    private void Update()
    {
        // Si un objet cible est d�fini et qu'une collision est en cours, mettre � jour sa position
        if (hasCollided == true && targetObject != null)
        {
            targetObject.transform.position = transform.position;
            
        }
    }
}
