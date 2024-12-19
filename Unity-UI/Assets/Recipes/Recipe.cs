using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.PlayerLoop;

[CreateAssetMenu(fileName = "New Recipe", menuName = "Recipe Book/Recipe")]
public class Recipe : ScriptableObject
{
    public string recipename;
    [TextArea]
    public string ingrediant;

}
