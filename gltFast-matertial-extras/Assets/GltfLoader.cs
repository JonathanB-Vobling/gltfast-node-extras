using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;
using GLTFast;
using GLTFast.Materials;
using UnityEngine.Networking;

public class GltfLoader : MonoBehaviour
{
    async void Start()
    {
        // can pass custom material generator to the GltfImport()
        var loader = new GltfImport(null, null, new CustomMaterialGenerator());
        
        
        var localUri = Application.dataPath + "/StreamingAssets/Default.glb";

        var success = await loader.Load(localUri);
        if (success)
        {
            loader.InstantiateMainScene(new GameObject("Default1").transform);
        }

        else
        {
            Debug.Log($"Loading failed");
        }
    }
}
