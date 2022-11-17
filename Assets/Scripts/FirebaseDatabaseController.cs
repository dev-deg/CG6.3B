using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;

public class FirebaseDatabaseController : MonoBehaviour
{
    private DatabaseReference _reference;
    public static FirebaseDatabaseController Instance
    {
        get;
        private set;
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        Instance = this;
        _reference = FirebaseDatabase.DefaultInstance.RootReference;
    }
    
    
    //Create a lobby instance and save it firebase real-time database
    public void CreateLobby(LobbyInstance lobby)
    {
        _reference.Child("lobbyData").Child(lobby.LobbyCode).SetRawJsonValueAsync(lobby.GetJson());
    }

    public void JoinLobby(String lobbyCode, String playerName)
    {
        _reference.Child("lobbyData").Child("banana").GetValueAsync().ContinueWithOnMainThread(task => {
                if (task.IsFaulted) {
                    // Handle the error...
                    Debug.LogError("Unable to read item for RTDB");
                }
                else if (task.IsCompleted) {
                    DataSnapshot snapshot = task.Result;
                    Dictionary<String, object> dict = new Dictionary<string, object>();
                    dict = (Dictionary<String, object>) snapshot.Value;
                    Debug.Log(dict["Player1Name"]);
                }
            });
    }
}
