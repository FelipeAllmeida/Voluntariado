using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDAO : DataAccessObject
{
    private const string TableName = "Event";
    private readonly string[] TableSelectKeys = { "eventID", "userAccount", "eventName", "message", "startDate", "endDate", "eventIconType", "maxNumber" };

    public override void AInitialize()
    {
        base.AInitialize();
    }

    public void GetAllEvents(Action<List<EventVO>> p_callbackFinish)
    {
        Dictionary<string, string> __dictWhere = new Dictionary<string, string>();
        __dictWhere.Add("1", "1");
        SelectDataFromTableAsync(SelectType.NONE, true, TableName, TableSelectKeys, __dictWhere, (List<Dictionary<string, string>> p_listData) =>
        {
            List<EventVO> __listEventVO = new List<EventVO>();
            if (p_listData != null && p_listData.Count > 0)
            {
                foreach (var k in p_listData)
                {
                    EventVO __eventVO = ConvertDictDataToEventVO(k);
                    __listEventVO.Add(__eventVO);
                }
            }

            if (p_callbackFinish != null)
                p_callbackFinish(__listEventVO);
        });
    }

    private EventVO ConvertDictDataToEventVO(Dictionary<string, string> p_dictData)
    {
        if (p_dictData == null || p_dictData.Count == 0)
            throw new ArgumentException("p_dictData is null or empty");

        EventVO __eventVO = new EventVO();
        __eventVO.eventID = p_dictData["eventID"];
        __eventVO.userAccount = p_dictData["userAccount"];
        __eventVO.eventName = p_dictData["eventName"];
        __eventVO.message = p_dictData["message"];
        __eventVO.startDate = DateTime.Parse(p_dictData["startDate"]);
        __eventVO.endDate = DateTime.Parse(p_dictData["endDate"]);
        __eventVO.eventIconType = (EventIconType)Enum.Parse(typeof(EventIconType), p_dictData["eventIconType"]);
        __eventVO.maxNumbers = int.Parse(p_dictData["maxNumber"]);

        return __eventVO;
    }
}
