using System;

[Serializable]
public class LobbyInstance
{
    public enum GAME_STATE
    {
        InLobby, GameRunning, GameFinished
    }
    private String _lobbyCode;
    private String _player1Name;
    private String _player2Name;
    private GAME_STATE _gameState;

    public LobbyInstance(string lobbyCode, string player1Name, string player2Name, GAME_STATE gameState = GAME_STATE.InLobby)
    {
        LobbyCode = lobbyCode;
        Player1Name = player1Name;
        Player2Name = player2Name;
        GameState = gameState;
    }

    public string LobbyCode
    {
        get => _lobbyCode;
        set => _lobbyCode = value;
    }

    public string Player1Name
    {
        get => _player1Name;
        set => _player1Name = value;
    }

    public string Player2Name
    {
        get => _player2Name;
        set => _player2Name = value;
    }

    public GAME_STATE GameState
    {
        get => _gameState;
        set => _gameState = value;
    }
}
