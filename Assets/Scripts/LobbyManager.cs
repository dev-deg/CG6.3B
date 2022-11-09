using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class LobbyManager : MonoBehaviour
{

    [SerializeField] private GameObject _welcomePanel;
    [SerializeField] private GameObject _joinPanel;
    [SerializeField] private GameObject _createPanel;
    [SerializeField] private GameObject _playerNameInput;
    [SerializeField] private GameObject _playerNameDisplay;
    private TMP_InputField _playerName;
    private TMP_InputField _playerDisplay;
    private FirebaseDatabaseController _dbInstance;
    void Start()
    {
        _dbInstance = FirebaseDatabaseController.Instance;
        _joinPanel.SetActive(false);
        _createPanel.SetActive(false);
        _playerName = _playerNameInput.GetComponent<TMP_InputField>();
        _playerDisplay = _playerNameDisplay.GetComponent<TMP_InputField>();
    }


    public void NavigateLobby(int lobbyId)
    {
        //Require a player to input his name to transition to other scenes
        if (_playerName.text.Length < 4)
        {
            return;
        }
        _playerDisplay.text = _playerName.text;
            switch (lobbyId)
        {
            //Create Lobby Panel
            case 1:
                _dbInstance.CreateLobby(new LobbyInstance("cookie-monster",_playerName.text,""));
                _welcomePanel.SetActive(false);
                _joinPanel.SetActive(false);
                _createPanel.SetActive(true);
                break;
            //Join Lobby Panel
            case 2:
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
}
