using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserDAO : DataAccessObject
{
    private const string UserTable = "User";
    private readonly string[] UserSelectKeys = { "account", "accountPassword", "name", "age", "volunteering", "rate" };

    public override void AInitialize()
    {
        base.AInitialize();
    }

    public void GetUserByAccountAndPassword(string p_account, string p_password, Action<UserVO> p_callbackFinish)
    {
        Dictionary<string, string> __dictWhere = new Dictionary<string, string>();
        __dictWhere.Add("account", p_account);
        __dictWhere.Add("accountPassword", p_password);
        GetUser(__dictWhere, p_callbackFinish);
    }

    private void GetUser(Dictionary<string, string> p_dictWhere, Action<UserVO> p_callbackFinish)
    {
        SelectDataFromTableAsync(SelectType.NONE, true, UserTable, UserSelectKeys, p_dictWhere, (List<Dictionary<string, string>> p_listData) =>
        {
            UserVO __userVO = null;

            if (p_listData != null || p_listData.Count > 0)
            {
                __userVO = ConvertDictDataToUserVO(p_listData[0]);
            }

            if (p_callbackFinish != null) p_callbackFinish(__userVO);
        });
    }

    private UserVO ConvertDictDataToUserVO(Dictionary<string, string> p_dictData)
    {
        if (p_dictData == null || p_dictData.Count == 0)
            throw new ArgumentException("p_dictData is null or empty");

        UserVO __userVO = new UserVO();

        __userVO.name = p_dictData["account"];
        __userVO.age = p_dictData["accountPassword"];
        __userVO.name = p_dictData["name"];
        __userVO.age = p_dictData["age"];
        __userVO.volunteering = bool.Parse(p_dictData["volunteering"]);
        __userVO.rate = float.Parse(p_dictData["rate"]);

        return __userVO;
    }
}
