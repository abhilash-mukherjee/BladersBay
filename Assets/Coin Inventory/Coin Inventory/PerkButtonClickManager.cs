using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerkButtonClickManager : MonoBehaviour
{
    public delegate void ButtonClickHandler(GameObject _GameObject);
    public static event ButtonClickHandler OnPerkButtonClicked;

    public void ButtonClicked()
    {
        OnPerkButtonClicked(gameObject);
    }
}
