using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;


public class LobbyManager : MonoBehaviour
{

    [SerializeField] private GameObject _welcomePanel;
    [SerializeField] private GameObject _joinPanel;
    [SerializeField] private GameObject _createPanel;
    [SerializeField] private GameObject _playerNameInput;
    [SerializeField] private GameObject _playerNameDisplay;
    [SerializeField] private GameObject _uniqueCodeDisplay; 
    
    private TMP_InputField _playerName;
    private TMP_InputField _playerDisplay;
    private TMP_InputField _uniqueCDisplay;
    private FirebaseDatabaseController _dbInstance;
    private List<String> _uniqueCodes;
    void Start()
    {
        _dbInstance = FirebaseDatabaseController.Instance;
        _joinPanel.SetActive(false);
        _createPanel.SetActive(false);
        _playerName = _playerNameInput.GetComponent<TMP_InputField>();
        _playerDisplay = _playerNameDisplay.GetComponent<TMP_InputField>();
        _uniqueCDisplay = _uniqueCodeDisplay.GetComponent<TMP_InputField>();
        StartCoroutine(LoadUniqueCodes(Application.dataPath + "/Scripts/UniqueJoinCodes.xml"));
    }


    public void NavigateLobby(int lobbyId)
    {
        //Require a player to input his name to transition to other scenes
        if (_playerName.text.Length < 4)
        {
            return;
        }
        
            switch (lobbyId)
        {
            //Create Lobby Panel
            case 1:
                String _uniqueCode = _uniqueCodes[Random.Range(0, _uniqueCodes.Count - 1)];
                //Updating the Create Lobby Panel
                _playerDisplay.text = _playerName.text;
                _uniqueCDisplay.text = _uniqueCode;
                //Saving the lobby instance in the database
                _dbInstance.CreateLobby(new LobbyInstance(_uniqueCode,_playerName.text,""));
                
                _welcomePanel.SetActive(false);
                _joinPanel.SetActive(false);
                _createPanel.SetActive(true);
                break;
            //Join Lobby Panel
            case 2:
                _dbInstance.JoinLobby("123","123");
                _welcomePanel.SetActive(false);
                _joinPanel.SetActive(true);
                _createPanel.SetActive(false);
                break;
            //Welcome Panel
            default:
                _welcomePanel.SetActive(true);
                _joinPanel.SetActive(false);
                _createPanel.SetActive(false);
                break;
        }
    }
    
    
    IEnumerator LoadUniqueCodes(String path)
    {
        XDocument doc = new XDocument(XDocument.Load(path));
        _uniqueCodes = new List<string>();
        foreach (XElement xElement in doc.Root.Elements())
        {
            _uniqueCodes.Add(xElement?.Value);
        }

        yield return null;
    }
}
