using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NoticeIconType
{
    NOTICE_0,
    NOTICE_1,
    NOTICE_2,
    NOTICE_3,
    NOTICE_4,
    NOTICE_5,
    NOTICE_6,
    NOTICE_7,
    NOTICE_8,
    NOTICE_9
}

public class NoticeIconProvider : MonoBehaviour 
{
    [Serializable]
    public class NoticeIconProviderData
    {
        public NoticeIconType noticeIconType;
        public Sprite sprite;
    }

    public static NoticeIconProvider instance;

    public List<NoticeIconProviderData> listNoticeIconProviderData;
    public Dictionary<NoticeIconType, Sprite> dictNoticeIconSprites;

    void Start () 
    {
        instance = this;
        dictNoticeIconSprites = new Dictionary<NoticeIconType, Sprite>();

        foreach (NoticeIconProviderData __data in listNoticeIconProviderData)
        {
            dictNoticeIconSprites.Add(__data.noticeIconType, __data.sprite);
        }
    }
}
