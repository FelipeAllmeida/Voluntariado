using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventPanel : Panel 
{
    public EventElement EventElementPrefab;

    [SerializeField]
    private Transform _layoutGroup;

    private List<EventElement> _listEventElements;

    public override void AInitialize()
    {
        base.AInitialize();
    }

    public override void Activate()
    {
        InitializeListEvents();
        base.Activate();
    }

    private void InitializeListEvents()
    {
        if (_listEventElements == null)
        {
            DataManager.instance.EventDAO.GetAllEvents((List<EventVO> p_listEventVO) =>
            {
                try
                {
                    _layoutGroup.GetComponent<RectTransform>().sizeDelta = new Vector2(_layoutGroup.GetComponent<RectTransform>().sizeDelta.x, 1550 * p_listEventVO.Count);
                    _listEventElements = new List<EventElement>();
                    for (int i = 0;i < p_listEventVO.Count;i++)
                    {
                        EventElement __eventElement = Instantiate(EventElementPrefab, _layoutGroup).GetComponent<EventElement>();
                        __eventElement.SetEventElement(p_listEventVO[i]);
                        _listEventElements.Add(__eventElement);
                    }
                }
                catch (Exception e)
                {
                    Debug.Log(e);
                }
            });
        }
    }
}
