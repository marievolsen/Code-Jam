using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//code based on https://www.youtube.com/watch?v=texonivDsy0&t=833s&ab_channel=BigfootCodes

public class ShowPanelButton : MonoBehaviour
{
    public string PanelId;

    private PanelManager _panelManager;

    private void Start()
    {
        _panelManager = PanelManager.Instance;
    }

    public void DoShowPanel()
    {
        _panelManager.ShowPanel(PanelId);
    }
}
