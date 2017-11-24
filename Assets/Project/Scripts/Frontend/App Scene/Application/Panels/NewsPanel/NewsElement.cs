using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class NewsElementData
{
    public string userName;
    public string userMessage;
    public Sprite messagePicture;
    public Sprite userPicture;
}

public class NewsElement : MonoBehaviour 
{
    public Text userNameText;
    public Text messageText;

    public Image userPicture;
    public Image messagePicture;

    public void SetNewsElement(NewsElementData p_data)
    {
        userNameText.text = p_data.userName;
        messageText.text = p_data.userMessage;

        userPicture.sprite = p_data.userPicture;
        messagePicture.sprite = p_data.messagePicture;
    }

    public void SetNewsElement(NoticeVO p_noticeVO)
    {
        UserVO __userVO = DataManager.instance.UserDAO.GetUserByAccount(p_noticeVO.userAccount);
        userNameText.text = __userVO.name;
        messageText.text = p_noticeVO.message;

        userPicture.sprite = UserIconProvider.instance.dictUserIconSprites[__userVO.userIconType];
        messagePicture.sprite = NoticeIconProvider.instance.dictNoticeIconSprites[p_noticeVO.noticeIconType];
    }
}
