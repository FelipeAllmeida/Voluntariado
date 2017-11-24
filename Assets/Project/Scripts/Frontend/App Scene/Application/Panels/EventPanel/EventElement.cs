using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class EventElementData
{
    public string userName;
    public string eventName;
    public string userMessage;
    public DateTime startDate;
    public DateTime endDate;

    public Sprite userPicture;
    public Sprite messagePicture;
}

public class EventElement : MonoBehaviour
{
    public Text userNameText;
    public Text eventNameText;
    public Text messageText;

    public Image userPicture;
    public Image messagePicture;

    public void SetEventElement(EventVO p_eventVO)
    {
        UserVO __userVO = DataManager.instance.UserDAO.GetUserByAccount(p_eventVO.userAccount);
        userNameText.text = __userVO.name;
        eventNameText.text = string.Format("{0} - {1} até {2}", p_eventVO.eventName, p_eventVO.startDate.ToString("dd/MM/yy"), p_eventVO.endDate.ToString("dd/MM/yy"));
        messageText.text = p_eventVO.message;

        userPicture.sprite = UserIconProvider.instance.dictUserIconSprites[__userVO.userIconType];
        messagePicture.sprite = EventIconProvider.instance.dictEventIconSprites[p_eventVO.eventIconType];
    }
}
