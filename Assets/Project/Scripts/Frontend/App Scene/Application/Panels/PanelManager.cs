using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour 
{
    public NewsPanel newsPanel;
    public EventPanel eventPanel;
    public FavoritesPanel favoritePanel;
    public DonationPanel donationPanel;
    public AboutPanel aboutPanel;
    public UserPanel userPanel;

    private Panel _currentPanel;
    private Dictionary<Panel.Type, Panel> _dictPanels;

    public void AInitialize()
    {
        InitializeDictPanels();
    }

    public void Activate()
    {
        ChangePanel(Panel.Type.NEWS);
    }

    private void InitializeDictPanels()
    {
        _dictPanels = new Dictionary<Panel.Type, Panel>();
        _dictPanels.Add(Panel.Type.NEWS, newsPanel);
        _dictPanels.Add(Panel.Type.EVENT, eventPanel);
        _dictPanels.Add(Panel.Type.FAVORITE, favoritePanel);
        _dictPanels.Add(Panel.Type.DONATION, donationPanel);
        _dictPanels.Add(Panel.Type.ABOUT, aboutPanel);
        _dictPanels.Add(Panel.Type.USER, userPanel);

        foreach (Panel __panel in _dictPanels.Values)
        {
            if (__panel != null)
                __panel.AInitialize();
        }

    }

    public void ChangePanel(Panel.Type p_panelType)
    {
        if (_currentPanel != null)
        {
            _currentPanel.Deactivate();

            if (p_panelType == _currentPanel.GetPanelType())
                return;
        }

        _currentPanel = _dictPanels[p_panelType];

        _currentPanel.Activate();
    }

    public void Update()
    {
        if (_currentPanel != null)
        {
            _currentPanel.AUpdate();
        }
    }
}
