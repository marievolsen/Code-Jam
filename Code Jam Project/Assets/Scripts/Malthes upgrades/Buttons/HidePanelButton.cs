using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidePanelButton : MonoBehaviour
{
    //this gets the PanelManager
    private PanelManager _panelManager;
    

    private void Start()
    {
         // makes an instance of the panelmanager.
        _panelManager = PanelManager.Instance;
    }
    // hides the last used panel in the queue.
    public void DoHidePanel()
    {
        _panelManager.HideLastPanel();
    }
}
