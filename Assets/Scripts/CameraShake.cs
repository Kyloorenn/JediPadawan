using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class CameraShake : MonoBehaviour
{
    Player player;
    private Camera _mainCamera;
    private Vector3 _initCamPos;
    private bool _shaking;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        _mainCamera = Camera.main;
    }
    void Update()
    {
        // avoiding multiple shakes, optimising the computation by using bool
        if (player.IsInvincible == true && !_shaking && player.isParry == false)
            StartCoroutine(_ShakingCamera());
    }

    private IEnumerator _ShakingCamera(float magnitude = 0.12f)
    {
        _shaking = true;
        //camera is shaking around player gameobject
        _initCamPos = _mainCamera.transform.position;
        float t = 0f, x, y;
        while (t < 0.7f)
        {
            x = UnityEngine.Random.Range(-1f, 1f) * magnitude;
            y = UnityEngine.Random.Range(-1f, 1f) * magnitude;

            _mainCamera.transform.position = new Vector3(player.transform.position.x+x, player.transform.position.y + y, _initCamPos.z);

            t += Time.deltaTime;
            yield return null;
        }
        //return to primary location
        _mainCamera.transform.position = new Vector3(player.transform.position.x , player.transform.position.y , _initCamPos.z);
        _shaking = false;
    }
}