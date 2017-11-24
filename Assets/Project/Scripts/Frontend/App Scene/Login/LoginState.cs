using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Framework;

public class LoginState : State<AppScene.StateType>
{
    #region Private Serialized Data
    [SerializeField] private InputField _accountField;
    [SerializeField] private InputField _accountPasswordField;
    [SerializeField] private Button _continueButton;
    #endregion

    public override void Enable()
    {
        Screen.SetResolution(1600, 2560, false);
        DataManager.instance.AInitialize(null);
        ListenEvents();
        gameObject.SetActive(true);
    }

    public override void Disable()
    {
        gameObject.SetActive(false);
    }

    private void ListenEvents()
    {
        _continueButton.onClick.AddListener(HandleOnContinueButtonClick);
    }

    private void HandleOnContinueButtonClick()
    {
        UserVO __userVO = DataManager.instance.UserDAO.GetUserByAccountAndPassword(_accountField.text, _accountPasswordField.text);

        if (__userVO != null)
        {
            UserData.SetMainUser(__userVO);
            stateMachine.ChangeToState(AppScene.StateType.APPLICATION);
        }
    }
}
