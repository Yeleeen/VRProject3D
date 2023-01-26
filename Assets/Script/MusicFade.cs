using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class MusicFade : MonoBehaviour
{
    public float fadeInTime = 1f;
    public float fadeOutTime = 1f;
    public AudioSource currentMusic;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        StartCoroutine(FadeInMusic(currentMusic, fadeInTime));
    }

    private void OnSceneUnloaded(Scene scene)
    {
        StartCoroutine(FadeOutMusic(currentMusic, fadeOutTime));
    }

    IEnumerator FadeInMusic(AudioSource music, float fadeTime)
    {
        music.volume = 0;
        music.Play();
        for (float i = 0f; i <= 1f; i += Time.deltaTime / fadeTime)
        {
            music.volume = i;
            yield return null;
        }
    }

    IEnumerator FadeOutMusic(AudioSource music, float fadeTime)
    {
        for (float i = 1f; i >= 0; i -= Time.deltaTime / fadeTime)
        {
            music.volume = i;
            yield return null;
        }
        music.Stop();
    }
}
