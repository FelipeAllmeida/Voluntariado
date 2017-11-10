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

    public static int connectedPlayers = 0;
    #region Private Data

    private LocalConnector _localConnector;

    #region DAO
    #endregion

    #endregion

    public void AInitialize(Action p_callbackFinish)
    {
        _localConnector = new LocalConnector();
        _localConnector.AInitialize();

    }
}
