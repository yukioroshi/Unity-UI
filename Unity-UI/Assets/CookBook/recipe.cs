using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.PlayerLoop;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
public class Recipe : ScriptableObject
{
    public string recipename;
    public string ingrediant;

    [SerializeField]
    private TMPro.TextMeshProUGUI recipeText;

    void AddToBook()
    {
        recipeText.text = recipename;
    }
}
