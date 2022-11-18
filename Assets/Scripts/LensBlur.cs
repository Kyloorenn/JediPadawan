using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class LensBlur : MonoBehaviour
{
  

    // Start is called before the first frame update
    private PostProcessVolume postProcessVolume;
    private DepthOfField depthOfField;

    void Start()
    {
       /* postProcessVolume = GetComponent<PostProcessVolume>();
        postProcessVolume.profile.TryGetSettings(out DepthOfField depthOfField);

        depthOfField.focusDistance.value = 0.1f; */
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
