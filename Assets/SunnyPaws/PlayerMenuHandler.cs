using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMenuHandler : MonoBehaviour
{
    public KeyValuePair<Button, IMenuHandler>[] Menus;
    private IMenuHandler _CurrentlyOpenedMenu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
