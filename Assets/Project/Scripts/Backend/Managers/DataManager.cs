using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager
{
    #region Singleton
    private static DataManager _instance;
    public static DataManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new DataManager();
            }
            return _instance;
        }
    }
    #endregion

    #region Private Data

    private LocalConnector _localConnector;

    #region DAO
    private UserDAO _userDAO;
    public UserDAO UserDAO 
    {
        get
        {
            return _userDAO;
        }
    }
    #endregion

    #endregion

    public void AInitialize(Action p_callbackFinish)
    {
        _localConnector = new LocalConnector();
        _localConnector.AInitialize();

        InitializeDataAccessObjects();
    }

    private void InitializeDataAccessObjects()
    {
        _userDAO = new UserDAO();
        _userDAO.AInitialize();
    }
}
