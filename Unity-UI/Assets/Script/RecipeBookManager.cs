#if UNITY_EDITOR
using UnityEditor; // Nécessaire pour AssetDatabase
#endif


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class RecipeBookManager : MonoBehaviour
{
    public List<Recipe> recipes = new List<Recipe>();
    //public Recipe[] recipes; // Liste de recettes
    public TextMeshProUGUI recipeNameText;
    public TextMeshProUGUI recipeDescriptionText;

    [Header("UI Input Fields")]
    public TMP_InputField recipeNameInputField;
    public TMP_InputField recipeDescriptionInputField;

    public GameObject player;
    public GameObject AddRecipeUi;

    private int currentIndex = 0;

    public bool RecipeUiOpen;

    public PlayerBehaviourScript playermove;

    void Start()
    {
        AddRecipeUi.SetActive(false);
        RecipeUiOpen = false;

        LoadAllRecipes();
        if (recipes.Count > 0)
            DisplayRecipe(currentIndex);
    }

    private void Update()
    {
        if (RecipeUiOpen == true)
        {
            playermove.enabled = false;
        }
        else
        {
            playermove.enabled = true;
        }
    }

    public void LoadAllRecipes()
    {
#if UNITY_EDITOR
        // Chemin du dossier contenant les recettes
        string[] guids = AssetDatabase.FindAssets("t:Recipe", new[] { "Assets/Recipes" });

        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            Recipe recipe = AssetDatabase.LoadAssetAtPath<Recipe>(path);
            recipes.Add(recipe);
        }

        Debug.Log($"Chargé {recipes.Count} recettes dans le livre.");
#endif
    }

    public void DisplayRecipe(int index)
    {
        if (recipes.Count == 0) return;

        currentIndex = Mathf.Clamp(index, 0, recipes.Count - 1);
        recipeNameText.text = recipes[currentIndex].recipename;
        recipeDescriptionText.text = recipes[currentIndex].ingrediant;
    }

    public void NextRecipe()
    {
        DisplayRecipe(currentIndex + 1);
    }

    public void PreviousRecipe()
    {
        DisplayRecipe(currentIndex - 1);
    }


    public void OpenAddRecipeUI()
    {
        AddRecipeUi.SetActive(true);
        RecipeUiOpen = true;
    }

    public void CloseAddRecipeUI()
    {
        AddRecipeUi.SetActive(false);
        RecipeUiOpen = false;

        // Réinitialiser les champs InputField
        recipeNameInputField.text = "";
        recipeDescriptionInputField.text = "";
    }

    public void AddRecipe()
    {
        AddRecipeUi.SetActive(false);
        RecipeUiOpen = false;

        string newRecipeName = recipeNameInputField.text;
        string newRecipeDescription = recipeDescriptionInputField.text;

        if (string.IsNullOrEmpty(newRecipeName) || string.IsNullOrEmpty(newRecipeDescription))
        {
            Debug.LogWarning("Nom ou description de la recette est vide !");
            return;
        }

        // Créer une nouvelle instance de recette
        Recipe newRecipe = ScriptableObject.CreateInstance<Recipe>();
        newRecipe.recipename = newRecipeName;
        newRecipe.ingrediant = newRecipeDescription;

        // Ajouter à la liste des recettes
        recipes.Add(newRecipe);

#if UNITY_EDITOR
        // Sauvegarder comme fichier dans le projet Unity
        string path = $"Assets/Recipes/{newRecipeName}.asset";
        AssetDatabase.CreateAsset(newRecipe, path);
        AssetDatabase.SaveAssets();
        Debug.Log($"Recette sauvegardée : {path}");
#endif

        // Réinitialiser les champs InputField
        recipeNameInputField.text = "";
        recipeDescriptionInputField.text = "";

        Debug.Log($"Recette ajoutée : {newRecipeName}");
    }



}
