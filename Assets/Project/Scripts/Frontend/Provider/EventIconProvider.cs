using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EventIconType
{
    EVENT_0,
    EVENT_1,
    EVENT_2,
    EVENT_3,
    EVENT_4,
    EVENT_5,
    EVENT_6,
    EVENT_7,
    EVENT_8,
    EVENT_9
}

public class EventIconProvider : MonoBehaviour 
{
    [Serializable]
    public class EventIconProviderData
    {
        public EventIconType eventIconType;
        public Sprite sprite;
    }

    public static EventIconProvider instance;

    public List<EventIconProviderData> listEventIconProviderData;
    public Dictionary<EventIconType, Sprite> dictEventIconSprites;

    void Start()
    {
        instance = this;
        dictEventIconSprites = new Dictionary<EventIconType, Sprite>();

        foreach (EventIconProviderData __data in listEventIconProviderData)
        {
            dictEventIconSprites.Add(__data.eventIconType, __data.sprite);
        }
    }
}
