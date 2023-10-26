using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ZoneChanger : MonoBehaviour
{
    public Camera mainCamera;
    public Light2D globalLight;
    public PlayerScript player;

    public AudioClip music;
    public float lightIntensity;

    public float transitionDuration = 2.0f;
    
    public void Start(){
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        globalLight = GameObject.FindGameObjectWithTag("GlobalLight").GetComponent<Light2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
    }

    private void OnTriggerEnter2D(){
        if(mainCamera.GetComponent<AudioSource>().clip != music){
            mainCamera.GetComponent<AudioSource>().clip = music;
            mainCamera.GetComponent<AudioSource>().Play();
        }
        if(globalLight.intensity != lightIntensity){
            float initialLightIntensity = globalLight.intensity;
            StartCoroutine(ChangeLight(lightIntensity, transitionDuration, initialLightIntensity));
        }

    }

    IEnumerator ChangeLight(float targetIntensity, float duration, float initialIntensity){
        float elapsedTime = 0f;

        while(elapsedTime < duration){
            globalLight.intensity = Mathf.Lerp(initialIntensity, targetIntensity, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        globalLight.intensity = targetIntensity;
    }
}
