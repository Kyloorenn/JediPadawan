using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;


public class TitleCamera : MonoBehaviour
{
    List<Color> colorlist = new List<Color>() { Color.yellow, Color.cyan,Color.blue,Color.magenta,Color.red };
    int i = 0;
    public Volume volume;
    public Vignette vignette;
    public DepthOfField depthOfField;
    public ChromaticAberration chromaticAberration;
    private float tuning = 2.5f;
    public bool isStart = false; //click Start Button
    // Start is called before the first frame update
    void Start()
    {
        volume = GetComponent<Volume>();
        volume.profile.TryGet(out vignette);
        volume.profile.TryGet(out depthOfField);
        volume.profile.TryGet(out chromaticAberration);
        vignette.color.value = colorlist[0];
    }
    public void NormalLensBlur()
    {
        depthOfField.focusDistance.Override(3f);
    }
    public void TitleLensBlur()
    {
        depthOfField.focusDistance.Override(1.0f);
    }
    public void LensBlur()
    {
        depthOfField.focusDistance.Override(0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (isStart)
        {
            chromaticAberration.intensity.value += 0.5f * Time.deltaTime;
        }      
        tuning -= Time.deltaTime;
        if(tuning <= 0f)
        {
            
            tuning = 2.5f;
            i++;
            if(i == 5)
            {
                i = 0;
            }
            vignette.color.value = colorlist[i];
        }  
        float flex = Mathf.Lerp(0f, 0.6f,tuning/ 2.5f);
        vignette.intensity.Override(flex);
    }
    
}
