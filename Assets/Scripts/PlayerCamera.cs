using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;


public class PlayerCamera : MonoBehaviour
{
    [SerializeField] public Transform target;
    [SerializeField] Transform[] targets;
    [SerializeField] public float speed = 10f;
    private ParticleSystem ps;
    Player player;
    public Volume volume;
    public Vignette vignette;
    public SplitToning splitToning;
    public DepthOfField depthOfField;
    public ChromaticAberration chromaticAberration;
    
    private void Start()
    {
      player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
      volume = GetComponent<Volume>();
      volume.profile.TryGet(out vignette);
      volume.profile.TryGet(out depthOfField);
      volume.profile.TryGet(out splitToning);
      volume.profile.TryGet(out chromaticAberration);
        ps = GetComponent<ParticleSystem>();
        //splitToning.highlights = new ColorParameter(UnityEngine.Color.clear);
        //splitToning.shadows = new ColorParameter(UnityEngine.Color.clear);
        /* postProcessVolume = GetComponent<PostProcessVolume>();
         postProcessVolume.profile.TryGetSettings(out UnityEngine.Rendering.PostProcessing.DepthOfField depthOfField);
         depthOfField.focusDistance.value = 0.1f; */
        if (Titlemanage.saveData.isone == true)
        {
            target = targets[0];
        }
        else
        {
            target = targets[1];
        }
    }

    public void ParryColor()
    {
        splitToning.highlights = new ColorParameter(UnityEngine.Color.blue);
        splitToning.shadows = new ColorParameter(UnityEngine.Color.black);
    }
    public void GetHealed()
    {
        splitToning.balance.Override(-50f);
    }
    public void Chromatic()
    {
        chromaticAberration.intensity.Override(0.7f);
    }
    public void NormalChromatic()
    {
        chromaticAberration.intensity.Override(0.1f);
    }
    public void LensBlur()
    {
        depthOfField.focusDistance.Override(0.1f);
    }

    public void NormalLensBlur()
    {
        depthOfField.focusDistance.Override(3f);
    }
    private void Update()
    {
        
      vignette.intensity.Override(1 - player.GetHPRatio());
        if (target == null)
        {
            return;
        }
        
        var targetPosition = new Vector3(target.position.x, target.position.y, -10);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.unscaledDeltaTime);

        if (splitToning.balance.value >= -100f)
        {
            splitToning.balance.value -= 25f * Time.deltaTime;

        }
    }
}
