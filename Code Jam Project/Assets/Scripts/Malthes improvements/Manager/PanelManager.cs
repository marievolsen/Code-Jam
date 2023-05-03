using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;

//code based on https://www.youtube.com/watch?v=texonivDsy0&t=833s&ab_channel=BigfootCodes

// This class enherits the singleton script making it a singleton.
public class PanelManager : Singleton<PanelManager>
{
    // A list that holds the PanelModels
    public List<PanelModel> Panels;

    // A list that holds the PanelInstanceModels 
    private List<PanelInstanceModel> _listInstance = new List<PanelInstanceModel>();


    // The ShowPanel function is a public method that returns nothing, and has the parameters of a string called panelId.
    public void ShowPanel(string panelId)
    {
        // This gets the panel model from the panels Firstordefault function and sets the panelId
        PanelModel panelModel = Panels.FirstOrDefault(Panel => Panel.PanelId == panelId);

        /* This if/else statement controls if there is any panel models and if there is, it instantiate a new panel instance from the panel prefabs.
        // it gets instantiated at the localposition of the transform and gets zeroed out. Furthermore it adds a new PanelInstanceModel to the instance list.
         if no PanelModel is available it will display the debug.LogWarning in the console. */
        if (panelModel != null)
        {
            var newInstancePanel = Instantiate(panelModel.PanelPrefab, transform);
            newInstancePanel.transform.localPosition = Vector3.zero;

            _listInstance.Add(new PanelInstanceModel
            {
                PanelId = panelId,
                PanelInstance = newInstancePanel
            });

        }
        else
        {
            Debug.LogWarning($"trying to find panels, but no can do");
        }
    }
    /* This function is called in the HidepanelButton Script. It uses an if statement that checks the function AnyPanelShowing().
    // It makes a variabel called lastPanel and sets the instance list count to 1 less than it was. 
     Then it removes the last panel from the list and destroys the PanelInstance.*/
    public void HideLastPanel()
    {
        if(AnyPanelShowing())
        {
            var lastPanel = _listInstance[_listInstance.Count -1];

            _listInstance.Remove(lastPanel);

            Destroy(lastPanel.PanelInstance);
        }

    }
    // Gets the amount of panels in the queue that is over 0.
    public bool AnyPanelShowing()
    {
        return GetAmountPanelsInQueue() > 0;
    }

    // Returns the number of instances in the list
    public int GetAmountPanelsInQueue()
    {
        return _listInstance.Count;
        
    }
}

