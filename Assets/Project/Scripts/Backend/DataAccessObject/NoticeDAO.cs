using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoticeDAO : DataAccessObject 
{
    private const string TableName = "Notices";
    private readonly string[] TableSelectKeys = { "userAccount", "title", "message", "noticeIconType" };

    public override void AInitialize()
    {
        base.AInitialize();
    }

    public void GetAllNews(Action<List<NoticeVO>> p_callbackFinish)
    {
        Dictionary<string, string> __dictWhere = new Dictionary<string, string>();
        __dictWhere.Add("1", "1");
        SelectDataFromTableAsync(SelectType.NONE, true, TableName, TableSelectKeys, __dictWhere, (List<Dictionary<string, string>> p_listData) =>
        {
            List<NoticeVO> __listNoticeVO = new List<NoticeVO>();
            if (p_listData != null && p_listData.Count > 0)
            {
                foreach (var k in p_listData)
                {
                    NoticeVO __noticeVO = ConvertDictDataToNoticeVO(k);
                    __listNoticeVO.Add(__noticeVO);
                }
            }

            if (p_callbackFinish != null)
                p_callbackFinish(__listNoticeVO);
        });
    }

    private NoticeVO ConvertDictDataToNoticeVO(Dictionary<string, string> p_dictData)
    {
        if (p_dictData == null || p_dictData.Count == 0)
            throw new ArgumentException("p_dictData is null or empty");

        NoticeVO __noticeVO = new NoticeVO();

        __noticeVO.userAccount = p_dictData["userAccount"];
        __noticeVO.title = p_dictData["title"];
        __noticeVO.message = p_dictData["message"];
        __noticeVO.noticeIconType = (NoticeIconType)Enum.Parse(typeof(NoticeIconType), p_dictData["noticeIconType"]);

        return __noticeVO;
    }
}
