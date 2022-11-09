using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;

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
        
    }
}
