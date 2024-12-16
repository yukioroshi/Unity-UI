using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private string itemName;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) // Touche pour la main gauche
        {
            CollectForLeftHand();
        }
        else if (Input.GetKeyDown(KeyCode.E)) // Touche pour la main droite
        {
            CollectForRightHand();
        }
    }

    private void CollectForLeftHand()
    {
        FindObjectOfType<InventorySystem>().AddToLeftHand(itemName);
        Destroy(gameObject); // Supprimer l'objet collectable
    }

    private void CollectForRightHand()
    {
        FindObjectOfType<InventorySystem>().AddToRightHand(itemName);
        Destroy(gameObject); // Supprimer l'objet collectable
    }
}