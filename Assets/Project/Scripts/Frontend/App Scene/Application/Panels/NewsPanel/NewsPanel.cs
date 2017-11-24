using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewsPanel : Panel
{
    public GameObject NewsElementPrefab;

    [SerializeField]
    private Transform _layoutGroup;

    private List<NewsElement> _listNewsElement;

    public override void AInitialize()
    {
        base.AInitialize();
    }

    private void InitializeListNews()
    {
        if (_listNewsElement == null)
        {
            DataManager.instance.NoticeDAO.GetAllNews((List<NoticeVO> p_listNoticeVO) =>
            {
                _layoutGroup.GetComponent<RectTransform>().sizeDelta = new Vector2(_layoutGroup.GetComponent<RectTransform>().sizeDelta.x, 1550 * p_listNoticeVO.Count);
                _listNewsElement = new List<NewsElement>();
                for (int i = 0;i < p_listNoticeVO.Count;i++)
                {
                    NewsElement __newsElement = Instantiate(NewsElementPrefab, _layoutGroup).GetComponent<NewsElement>();
                    __newsElement.SetNewsElement(p_listNoticeVO[i]);
                    _listNewsElement.Add(__newsElement);
                }
            });
        }
    }

    public override void Activate()
    {
        InitializeListNews();

        base.Activate();
    }

    public override void Deactivate()
    {
        base.Deactivate();
    }

    public override void AUpdate()
    {
        base.AUpdate();
    }

}
