using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Inventory")]
public class Equipement : MonoBehaviour
{
    public EquipementType _type;



}

public enum EquipementType
{
    Right_hand, Left_hand
}
