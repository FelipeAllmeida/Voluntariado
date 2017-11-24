using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserDAO : DataAccessObject
{   
    private const string UserTable = "User";
    private readonly string[] UserSelectKeys = { "account", "accountPassword", "name", "age", "rate", "volunteering", "userType", "userIconType" };

    public override void AInitialize()
    {
        base.AInitialize();
    }

    public UserVO GetUserByAccount(string p_account)
    {
        Dictionary<string, string> __dictWhere = new Dictionary<string, string>();
        __dictWhere.Add("account", p_account);
        return GetUser(__dictWhere);
    }

    public UserVO GetUserByAccountAndPassword(string p_account, string p_password)
    {
        Dictionary<string, string> __dictWhere = new Dictionary<string, string>();
        __dictWhere.Add("account", p_account);
        __dictWhere.Add("accountPassword", p_password);
        return GetUser(__dictWhere);
    }

    private UserVO GetUser(Dictionary<string, string> p_dictWhere)
    {
        List<Dictionary<string, string>> __listDictResults = SelectDataFromTable(SelectType.NONE, true, UserTable, UserSelectKeys, p_dictWhere);
        
        UserVO __userVO = null;
        if (__listDictResults != null && __listDictResults.Count > 0)
        {
            __userVO = ConvertDictDataToUserVO(__listDictResults[0]);
        }

        return __userVO;
    }

    private UserVO ConvertDictDataToUserVO(Dictionary<string, string> p_dictData)
    {
        if (p_dictData == null || p_dictData.Count == 0)
            throw new ArgumentException("p_dictData is null or empty");

        UserVO __userVO = new UserVO();

        __userVO.name = p_dictData["account"];
        __userVO.accountPassword = p_dictData["accountPassword"];
        __userVO.name = p_dictData["name"];
        __userVO.age = int.Parse(p_dictData["age"]);
        __userVO.volunteering = bool.Parse(p_dictData["volunteering"]);
        __userVO.rate = float.Parse(p_dictData["rate"]);
        __userVO.userType = (UserVO.Type)Enum.Parse(typeof(UserVO.Type), p_dictData["userType"]);
        __userVO.userIconType = (UserIconType)Enum.Parse(typeof(UserIconType), p_dictData["userIconType"]);

        return __userVO;
    }
}
