using System;
using System.Collections.Generic;
using Firebase.Extensions;
using Firebase.Firestore;
using UnityEngine;

public class DataMining : MonoBehaviour
{
    public enum ActionType
    {
        ButtonClicked
    }
    private String _anonymisedUserId;
    private void Awake()
    {
        _anonymisedUserId = "jkhbr28oisjv913siasd";
    }

    public void RecordAdditionalClick()
    {
        FirebaseFirestore db = FirebaseFirestore.DefaultInstance;
        DocumentReference docRef = db.Collection("data-mining").Document();

        DateTime date = new DateTime();
        Dictionary<string, object> city = new Dictionary<string, object>
        {
            { "User", _anonymisedUserId },
            { "Action", ActionType.ButtonClicked.ToString()},
            { "DateTime", date.Date.ToString() }
        };
        docRef.SetAsync(city).ContinueWithOnMainThread(task => {
            Debug.Log("Added action to Firestore");
        });
    }
}
