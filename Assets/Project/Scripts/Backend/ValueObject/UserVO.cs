using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UserVO 
{
    public enum Type
    {
        USER,
        ADMIN,
        COMPANY
    }

    public string account;
    public string accountPassword;

    public string name;

    public bool volunteering;
    public int age;
    public float rate;
    public Type userType;
    public UserIconType userIconType;
}
