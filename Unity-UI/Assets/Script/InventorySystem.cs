using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    [SerializeField] private GameObject leftHandPanel; // Panel pour la main gauche
    [SerializeField] private GameObject rightHandPanel; // Panel pour la main droite
    [SerializeField] private GameObject buttonPrefab; // Préfab pour les boutons d'objet

    private List<string> leftHandInventory = new List<string>(); // Liste des objets dans la main gauche
    private List<string> rightHandInventory = new List<string>(); // Liste des objets dans la main droite

    public void AddToLeftHand(string itemName)
    {
        if (!leftHandInventory.Contains(itemName))
        {
            leftHandInventory.Add(itemName);
            AddButtonToPanel(itemName, leftHandPanel, leftHandInventory);
        }
    }

    public void AddToRightHand(string itemName)
    {
        if (!rightHandInventory.Contains(itemName))
        {
            rightHandInventory.Add(itemName);
            AddButtonToPanel(itemName, rightHandPanel, rightHandInventory);
        }
    }

    private void AddButtonToPanel(string itemName, GameObject panel, List<string> inventory)
    {
        GameObject newButton = Instantiate(buttonPrefab, panel.transform);
        newButton.GetComponentInChildren<UnityEngine.UI.Text>().text = itemName;
    }

    public void UseItem(string itemName, List<string> inventory, GameObject panel)
    {
        Debug.Log($"Used {itemName}.");
        inventory.Remove(itemName);
        UpdatePanelUI(inventory, panel);
    }

    private void UpdatePanelUI(List<string> inventory, GameObject panel)
    {
        foreach (Transform child in panel.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (string itemName in inventory)
        {
            AddButtonToPanel(itemName, panel, inventory);
        }
    }
}