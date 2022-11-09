using System;
using UnityEngine;

[Serializable]
public class LobbyInstance
{
    public String LobbyCode;
    public String Player1Name;
    public String Player2Name;
    public String GameState;

    public LobbyInstance(string lobbyCode, string player1Name, string player2Name, string gameState = "InLobby")
    {
        LobbyCode = lobbyCode;
        Player1Name = player1Name;
        Player2Name = player2Name;
        GameState = gameState;
    }

    public String GetJson()
    {
        return JsonUtility.ToJson(this);
    }
}
