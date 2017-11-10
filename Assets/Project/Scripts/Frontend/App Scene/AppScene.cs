using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Framework;

public class AppScene : Scene<AppScene.StateType>
{
    public enum StateType
    {
        LOGIN,
        APPLICATION
    }
}
