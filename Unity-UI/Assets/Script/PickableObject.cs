using UnityEngine;

public class Collectable : MonoBehaviour
{
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0)) // Si clic gauche
        {
            Debug.Log($"{gameObject.name} sélectionné");
        }
    }
}