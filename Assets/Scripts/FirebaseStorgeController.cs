using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using Firebase.Storage;
using Firebase.Extensions;

public class FirebaseStorgeController : MonoBehaviour
{
    
    private FirebaseStorage _firebaseInstance;
    private Image _downloadedImage;
    private RawImage _downloadedRawImage;
    public static FirebaseStorgeController Instance
    {
        get;
        private set;
    }
    
    
    private void Awake()
    {
        //Singleton Pattern
        if (Instance != this && Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(this); //GameManager
        _firebaseInstance = FirebaseStorage.DefaultInstance;
    }

    private void Start()
    {
        DownloadImage("gs://cg-02-6e2c8.appspot.com/Thumbnails/Image2.png");
        _downloadedRawImage = GameObject.Find("Downloaded_Raw_Image").GetComponent<RawImage>();
    }

    public void DownloadImage(string url){
        StorageReference storageRef =  _firebaseInstance.GetReferenceFromUrl(url);
        
        // Download in memory with a maximum allowed size of 1MB (1 * 1024 * 1024 bytes)
        const long maxAllowedSize = 1 * 1024 * 1024;
        storageRef.GetBytesAsync(maxAllowedSize).ContinueWithOnMainThread(task => {
            if (task.IsFaulted || task.IsCanceled) {
                Debug.LogException(task.Exception);
                // Uh-oh, an error occurred!
            }
            else {
                Debug.Log($"{storageRef.Name} finished downloading!");
                //Load the image into Unity
                StartCoroutine(LoadImage(task.Result));
            }
        });
        
    }

    IEnumerator LoadImage(byte[] byteArr)
    {
        Texture2D imageTex = new Texture2D(1, 1);
        imageTex.LoadImage(byteArr);
        //Using the Raw Image Component
        _downloadedRawImage.texture = imageTex;
        yield return null;
    }
    
}
