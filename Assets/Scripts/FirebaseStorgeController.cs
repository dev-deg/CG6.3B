using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Storage;
public class FirebaseStorgeController : MonoBehaviour
{
    
    private FirebaseStorage _reference;

    void Awake()
    {
        _reference = FirebaseStorage.DefaultInstance;
    }

    
}
