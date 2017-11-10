using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Framework;

public class ApplicationState : State<AppScene.StateType>
{


    public override void Enable()
    {
        gameObject.SetActive(true);
    }

    public override void Disable()
    {
        gameObject.SetActive(false);
    }
}
