using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerkButtonClickManager : MonoBehaviour
{
    public delegate void ButtonClickHandler(GameObject _GameObject);
    public delegate void InventoryUpdateHandler();
    public static event ButtonClickHandler OnPerkButtonClicked;
    public static event InventoryUpdateHandler OnInventoryUpdated;

    public void ButtonClicked()
    {
        OnPerkButtonClicked?.Invoke(gameObject);
        OnInventoryUpdated?.Invoke();
    }
}
