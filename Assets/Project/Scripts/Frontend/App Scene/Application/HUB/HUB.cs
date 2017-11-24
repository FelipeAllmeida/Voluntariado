using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUB : MonoBehaviour 
{
    public Action<Panel.Type> onRequestChangePanel;

    public Button newsPanelButton;
    public Button eventPanelButton;
    public Button favoritePanelButton;
    public Button donationPanelButton;
    public Button aboutPanelButton;
    public Button userPanelButton;

    public void AInitialize()
    {
        newsPanelButton.onClick.AddListener(() =>
        {
            if(onRequestChangePanel != null) 
            onRequestChangePanel(Panel.Type.NEWS);
        });

        eventPanelButton.onClick.AddListener(() =>
        {
            if (onRequestChangePanel != null)
                onRequestChangePanel(Panel.Type.EVENT);
        });

        favoritePanelButton.onClick.AddListener(() =>
        {
            if (onRequestChangePanel != null)
                onRequestChangePanel(Panel.Type.FAVORITE);
        });

        donationPanelButton.onClick.AddListener(() =>
        {
            if (onRequestChangePanel != null)
                onRequestChangePanel(Panel.Type.DONATION);
        });

        aboutPanelButton.onClick.AddListener(() =>
        {
            if (onRequestChangePanel != null)
                onRequestChangePanel(Panel.Type.ABOUT);
        });

        userPanelButton.onClick.AddListener(() =>
        {
            if (onRequestChangePanel != null)
                onRequestChangePanel(Panel.Type.USER);
        });
    }
}
