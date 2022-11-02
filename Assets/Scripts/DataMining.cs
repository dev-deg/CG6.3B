using System;
using System.Collections.Generic;
using Firebase.Extensions;
using Firebase.Firestore;
using UnityEngine;

public class DataMining : MonoBehaviour
{
    
    private FirebaseFirestore _db;
    private DocumentReference _docRef;
    public enum ActionType
    {
        ButtonClicked
    }
    private readonly String _anonymisedUserId = "jkhbr28oisjv913siasd";
    private void Awake()
    {
        _db = FirebaseFirestore.DefaultInstance;
        _docRef = _db.Collection("data-mining").Document();
    }

    public void RecordAdditionalClick()
    {
        Dictionary<string, object> city = new Dictionary<string, object>
        {
            { "User", _anonymisedUserId },
            { "Action", ActionType.ButtonClicked.ToString()},
            { "DateTime", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") }
        };
        _docRef.SetAsync(city).ContinueWithOnMainThread(task => {
            Debug.Log($"Added {ActionType.ButtonClicked.ToString()} action to Firestore");
        });
    }
}
