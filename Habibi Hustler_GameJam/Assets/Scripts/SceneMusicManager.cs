using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMusicManager : MonoBehaviour
{
    public AudioClip scene0Music;
    public AudioClip scene1Music;
    public AudioClip scene2Music;

    private AudioSource audioSource;

    private void Awake()
    {
        // Ensure only one MusicManager exists
        if (FindObjectsOfType<SceneMusicManager>().Length > 1)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject); // Optional: persist across scenes
        audioSource = GetComponent<AudioSource>();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayMusicForScene(scene.buildIndex);
    }

    private void PlayMusicForScene(int sceneIndex)
    {
        AudioClip clipToPlay = null;

        switch (sceneIndex)
        {
            case 0:
                clipToPlay = scene0Music;
                break;
            case 1:
                clipToPlay = scene1Music;
                break;
            case 2:
                clipToPlay = scene2Music;
                break;
        }

        if (clipToPlay != null && audioSource.clip != clipToPlay)
        {
            audioSource.clip = clipToPlay;
            audioSource.loop = true;
            audioSource.Play();
        }
    }
}
