using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using Firebase.Storage;
using Firebase.Extensions;
using UnityEngine.UI;

public class FirebaseStorgeController : MonoBehaviour
{
    
    private FirebaseStorage _instance;
    
    private void Awake()
    {
        _instance = FirebaseStorage.DefaultInstance;
    }

    private void Start()
    {
        DownloadImage("gs://cg-02-6e2c8.appspot.com/Thumbnails/Image1.png");
    }

    public void DownloadImage(string url){
        StorageReference storageRef =  _instance.GetReferenceFromUrl(url);
        
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
                Texture2D imageTex = new Texture2D(1, 1);
                imageTex.LoadImage(task.Result);
                Sprite downloadedImage = Sprite.Create(imageTex,new Rect(0,0,imageTex.width,
                    imageTex.height),new Vector2(imageTex.width/2,imageTex.height/2));
                GameObject.Find("Downloaded_Image").GetComponent<Image>().sprite = downloadedImage;
            }
        });
        
    }
    
}
