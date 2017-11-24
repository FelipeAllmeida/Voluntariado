using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Framework;

public class ApplicationState : State<AppScene.StateType>
{
    public PanelManager panelManager;
    public HUB hub;

    public override void AInitialize()
    {
        panelManager.AInitialize();
        hub.AInitialize();
        hub.onRequestChangePanel = panelManager.ChangePanel;
    }

    public override void Enable()
    {
        panelManager.Activate();
        gameObject.SetActive(true);
    }

    public override void Disable()
    {
        gameObject.SetActive(false);
    }
}
