using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject controllerIcon;
    public GameObject cablesIcon;
    public GameObject consoleIcon;
    public GameObject cartridgeIcon;
    public bool hasController;
    public bool hasCables;
    public bool hasConsole;
    public bool hasCartridge;

    private void updateInventory()
    {
        controllerIcon.SetActive(hasController);
        cablesIcon.SetActive(hasCables);
        cartridgeIcon.SetActive(hasCartridge);
        consoleIcon.SetActive(hasConsole);
    }

    // Update is called once per frame
    void Update()
    {
        updateInventory();
    }
}
