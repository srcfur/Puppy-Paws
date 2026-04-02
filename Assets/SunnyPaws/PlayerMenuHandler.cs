using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerMenuHandler : MonoBehaviour
{
    private MenuHandler _CurrentlyOpenedMenu;
    public void CloseCurrentMenu()
    {
        _CurrentlyOpenedMenu.CloseMenu();
    }
    public void OpenNewMenu(MenuHandler newmenu)
    {
        if(_CurrentlyOpenedMenu != null)
        {
            _CurrentlyOpenedMenu.CloseMenu();
        }
        _CurrentlyOpenedMenu = newmenu;
        _CurrentlyOpenedMenu.OpenMenu();
    }
}