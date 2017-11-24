using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum UserIconType
{
    USER_0,
    USER_1,
    USER_2,
    USER_3,
    USER_4,
    USER_5,
    USER_6,
    USER_7,
    USER_8,
    USER_9
}

public class UserIconProvider : MonoBehaviour 
{
    [Serializable]
    public class UserIconProviderData
    {
        public UserIconType userIconType;
        public Sprite sprite;
    }

    public static UserIconProvider instance;

    public List<UserIconProviderData> listUserIconProviderData;
    public Dictionary<UserIconType, Sprite> dictUserIconSprites;

    void Start()
    {
        instance = this;
        dictUserIconSprites = new Dictionary<UserIconType, Sprite>();

        foreach (UserIconProviderData __data in listUserIconProviderData)
        {
            dictUserIconSprites.Add(__data.userIconType, __data.sprite);
        }
    }   
}
