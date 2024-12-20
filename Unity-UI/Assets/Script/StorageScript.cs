using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StorageScript : MonoBehaviour
{
    public GameObject InventoryUI;

    [System.Serializable]
    public class InventorySlot
    {
        public TextMeshProUGUI itemText; // Text TMP pour afficher le nom de l'objet
        public string storedItem = "";  // Nom de l'objet stocké (vide si aucun)
    }

    public List<InventorySlot> slots;  // Liste des slots dans l'UI
    private List<string> availableItems = new List<string>
    {
        "Steak", "Aubergine"
    };

    private void Start()
    {
        ClearInventory();
    }

    //public void OpenInventory()
    //{
    //    ClearInventory();
    //    FillRandomSlots();
    //}

    private void ClearInventory()
    {
        // Vide tous les slots
        foreach (var slot in slots)
        {
            slot.storedItem = "";
            slot.itemText.text = "";
        }
    }

    private void FillRandomSlots()
    {
        // Remplit des slots aléatoires avec des objets
        int slotsToFill = Random.Range(1, slots.Count); // Remplit entre 1 et le nombre total de slots

        for (int i = 0; i < slotsToFill; i++)
        {
            int randomSlotIndex = Random.Range(0, slots.Count);
            var slot = slots[randomSlotIndex];

            if (string.IsNullOrEmpty(slot.storedItem)) // Si le slot est vide
            {
                string randomItem = availableItems[Random.Range(0, availableItems.Count)];
                slot.storedItem = randomItem;
                slot.itemText.text = randomItem;
            }
        }
    }



    public void OpenInvUI()
    {
        InventoryUI.SetActive(true);
        ClearInventory();
        FillRandomSlots();
    }

    public void CloseInvUI()
    {
        InventoryUI.SetActive(false);
    }
}