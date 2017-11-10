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
        DataManager.instance.UserDAO.GetUserByAccountAndPassword(_accountField.text, _accountPasswordField.text, (UserVO p_userVO) =>
        {
            if (p_userVO != null)
                stateMachine.ChangeToState(AppScene.StateType.APPLICATION);
        });
    }
}
