using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;

public class FirebaseDatabaseController : MonoBehaviour
{
    private DatabaseReference _reference;

    private void Awake()
    {
        _reference = FirebaseDatabase.DefaultInstance.RootReference;
    }
}
