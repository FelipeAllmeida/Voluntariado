using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Mono.Data.Sqlite;
using System.Data;

public class LocalConnector
{
    public static readonly string DBName = "Volunteering.sqdb";
    private IDbConnection _dbcon;
#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX
#endif
    // Need to load this name from a Config file
    private string _dbURI;

    private IDbCommand _dbCommand;
    private IDataReader _dbReader;
    private IDbTransaction _dbTransacion;
#if UNITY_STANDALONE_OSX
	private string _macDBPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal) + "/DBData";
#endif
#if UNITY_STANDALONE_WIN
    private string _windowsDBPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "/DownTownStudios/PunkHazard/DBData";
#endif
    // Use this for initialization
    public void AInitialize()
    {
        CreateDatabaseaAtCurrentPlatform();
    }

#if UNITY_ANDROID

    #region AndroidGetDatabasePath

	
	private void GetAndroidDatabasePath()
	{
	_dbURI = "URI=file:" + Application.persistentDataPath + "/" +  DBName;
	CreateDatabaseLogicForAndroid();
	}

	private void CreateDatabaseLogicForAndroid()
	{
	    if(File.Exists(Application.persistentDataPath + "/" + DBName) == false)
	    {
	        WWW www = new WWW ("jar:file://" + Application.dataPath + "!/assets/" + DBName);

	        while (!www.isDone) {}

	        System.IO.File.WriteAllBytes(Application.persistentDataPath + "/" + DBName, www.bytes);
	    }
	    else
	    {
	        WWW www = new WWW ("jar:file://" + Application.dataPath + "!/assets/" + DBName);

	        while (!www.isDone) {}

	        System.IO.File.WriteAllBytes(Application.persistentDataPath + "/" + DBName, www.bytes);

	    }
	}

	



    #endregion

	
#endif

#if UNITY_IOS
	



    #region IOSGetDatabasePath()

	
	private void GetIOSDatabasePath()
	{
	_dbURI = "URI=file:" + Application.persistentDataPath + "/" +  DBName;
	CreateDatabaseLogicForIOS();
	}

	private void CreateDatabaseLogicForIOS()
	{
	if(File.Exists(Application.persistentDataPath + "/" + DBName) == false)
	{
	System.IO.File.Copy(Application.dataPath + "/Raw/" +  DBName, Application.persistentDataPath + "/" + DBName, true);

	UnityEngine.iOS.Device.SetNoBackupFlag(Application.persistentDataPath + "/" + DBName);

	InsertBundleVersionDataInDatabase(CurrentBundleVersion.version);
	}
	else
	{
	string __foundVersion = CheckBundleVersion();

	if (__foundVersion != CurrentBundleVersion.version)
	{
	System.IO.File.Copy(Application.dataPath + "/Raw/" +  DBName, Application.persistentDataPath + "/" + DBName, true);

	InsertBundleVersionDataInDatabase(CurrentBundleVersion.version);

	UnityEngine.iOS.Device.SetNoBackupFlag(Application.persistentDataPath + "/" + DBName);
	}
	}
	}
	



    #endregion

	
#endif

#if UNITY_STANDALONE_OSX
	

    #region MacGetDatabasePath()

	
	private void GetMacDatabasePath ()
	{
		_dbURI = "URI=file:" + _macDBPath + "/" + DBNameDecrypted;
		CreateDatabaseLogicForMac ();
	}

	private void CreateDatabaseLogicForMac ()
	{
		if (Directory.Exists (_macDBPath) == true) {
			if (File.Exists (_macDBPath + "/" + DBName) == true) {
				if (File.Exists (_macDBPath + "/" + DBNameDecrypted) == true) {
					if (File.Exists (_macDBPath + "/" + DBName) == true) {
						File.Delete (_macDBPath + "/" + DBName);
					}

					SecureFile.EncryptFile (_macDBPath + "/" + DBNameDecrypted, _macDBPath + "/" + DBName);
				} else {
					SecureFile.DecryptFile (_macDBPath + "/" + DBName, _macDBPath + "/" + DBNameDecrypted);
				}

				string __foundVersion = CheckBundleVersion ();

				if (__foundVersion != CurrentBundleVersion.version) {
					if (File.Exists (_macDBPath + "/" + DBName) == true) {
						File.Delete (_macDBPath + "/" + DBName);
					}
					if (File.Exists (_macDBPath + "/" + DBNameDecrypted) == true) {
						File.Delete (_macDBPath + "/" + DBNameDecrypted);
					}

					File.Copy (Application.streamingAssetsPath + "/" + DBName, _macDBPath + "/" + DBName, true);

					SecureFile.DecryptFile (_macDBPath + "/" + DBName, _macDBPath + "/" + DBNameDecrypted);

					InsertBundleVersionDataInDatabase (CurrentBundleVersion.version);
				}
			} else {
				File.Copy (Application.streamingAssetsPath + "/" + DBName, _macDBPath + "/" + DBName, true);

				if (File.Exists (_macDBPath + "/" + DBNameDecrypted) == true) {
					if (File.Exists (_macDBPath + "/" + DBName) == true) {
						File.Delete (_macDBPath + "/" + DBName);
					}

					SecureFile.EncryptFile (_macDBPath + "/" + DBNameDecrypted, _macDBPath + "/" + DBName);
				} else {
					SecureFile.DecryptFile (_macDBPath + "/" + DBName, _macDBPath + "/" + DBNameDecrypted);
				}
			}
		} else {
			Directory.CreateDirectory (_macDBPath);
			File.Copy (Application.streamingAssetsPath + "/" + DBName, _macDBPath + "/" + DBName, true);
			SecureFile.DecryptFile (_macDBPath + "/" + DBName, _macDBPath + "/" + DBNameDecrypted);

			InsertBundleVersionDataInDatabase (CurrentBundleVersion.version);
		}
	}

	private void UpdateDatabaseOSX ()
	{
		if (File.Exists (_macDBPath + "/" + DBNameDecrypted) == true) {
			if (File.Exists (_macDBPath + "/" + DBName) == true) {
				File.Delete (_macDBPath + "/" + DBName);
			}
			SecureFile.EncryptFile (_macDBPath + "/" + DBNameDecrypted, _macDBPath + "/" + DBName);
			File.Delete (_macDBPath + "/" + DBNameDecrypted);
		}
	}

	

    #endregion

	
#endif

#if UNITY_STANDALONE_WIN
    
    #region WindowsGetDatabasePath

    private void CreateDatabaseLogicForWindows()
    {
        Debug.Log("CreateDatabaseLogicForWindows");
        if (Directory.Exists(_windowsDBPath) == true)
        {
            Debug.Log("Directory Exists: " + _windowsDBPath);
            if (File.Exists(_windowsDBPath + "/" + DBName) == true)
            {
                File.Delete(_windowsDBPath + "/" + DBName);
                File.Copy(Application.streamingAssetsPath + "/" + DBName, _windowsDBPath + "/" + DBName, true);
            }
            /*//if (File.Exists(_windowsDBPath + "/" +DBName) == true)
            {
                if (File.Exists(_windowsDBPath + "/" +DBNameDecrypted) == true)
                {
                    if (File.Exists(_windowsDBPath + "/" +DBName) == true)
                    {
                        File.Delete(_windowsDBPath + "/" +DBName);
                    }
                }
                else
                {
                }

                string __foundVersion = CheckBundleVersion();

                if (__foundVersion != CurrentBundleVersion.version)
                {
                    if (File.Exists(_windowsDBPath + "/" +DBName) == true)
                    {
                        File.Delete(_windowsDBPath + "/" +DBName);
                    }
                    if (File.Exists(_windowsDBPath + "/" +DBNameDecrypted) == true)
                    {
                        File.Delete(_windowsDBPath + "/" +DBNameDecrypted);
                    }

                    File.Copy(Application.streamingAssetsPath + "/" +DBName, _windowsDBPath + "/" +DBName, true);

                    SecureFile.DecryptFile(_windowsDBPath + "/" +DBName, _windowsDBPath + "/" +DBNameDecrypted);

                    InsertBundleVersionDataInDatabase(CurrentBundleVersion.version);
                }
            }
            else
            {
                File.Copy(Application.streamingAssetsPath + "/" +DBName, _windowsDBPath + "/" +DBName, true);

                if (File.Exists(_windowsDBPath + "/" +DBNameDecrypted) == true)
                {
                    if (File.Exists(_windowsDBPath + "/" +DBName) == true)
                    {
                        File.Delete(_windowsDBPath + "/" +DBName);
                    }
                    SecureFile.EncryptFile(_windowsDBPath + "/" +DBNameDecrypted, _windowsDBPath + "/" +DBName);
                }
                else
                {
                    SecureFile.DecryptFile(_windowsDBPath + "/" +DBName, _windowsDBPath + "/" +DBNameDecrypted);
                }
            }*/
        }
        else
        {
            Debug.Log("Create Directory: " + _windowsDBPath);
            Directory.CreateDirectory(_windowsDBPath);
            File.Copy(Application.streamingAssetsPath + "/" +DBName, _windowsDBPath + "/" +DBName, true);
        }
    }


    #endregion

#endif

#if UNITY_EDITOR
    #region EditorGetDatabasePath

    private void GetEditorDatabasePath()
    {
        _dbURI = "URI = file:" +Application.dataPath + "/ StreamingAssets /" +DBName;
    }

    #endregion

#endif

    private void CreateDatabaseaAtCurrentPlatform()
    {
        //Debug.Log("CreateDatabaseaAtCurrentPlatform");
#if UNITY_EDITOR
        {
            GetEditorDatabasePath();
        }
#elif   UNITY_IOS
		{
		GetIOSDatabasePath();
		}
#elif UNITY_ANDROID
		{
		GetAndroidDatabasePath();
		}
#elif UNITY_STANDALONE_WIN
		{
		CreateDatabaseLogicForWindows();		
		}
#elif UNITY_STANDALONE_OSX
		{
		GetMacDatabasePath();
		}
#endif
    }
}