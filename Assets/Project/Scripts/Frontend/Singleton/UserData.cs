using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UserData 
{
    private static UserVO _userVO;
    public static UserVO userVO { get { return _userVO; } }

    public static void SetMainUser(UserVO p_userVO)
    {
        _userVO = p_userVO;
    }

    public static void SetVolunteering(bool p_value)
    {
        _userVO.volunteering = p_value;
    }
}
