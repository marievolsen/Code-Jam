using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//code based on https://www.youtube.com/watch?v=texonivDsy0&t=833s&ab_channel=BigfootCodes
public class HidePanelButton : MonoBehaviour
{
    //this gets the PanelManager
    private PanelManager _panelManager;
    

    private void Start()
    {
         // makes an instance of the panelmanager.
        _panelManager = PanelManager.Instance;
    }
    // hides the last used panel in the queue by calling the HideLastPanel method from the PanelManager. 
    public void DoHidePanel()
    {
        _panelManager.HideLastPanel();
    }
}
