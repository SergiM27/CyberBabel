using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;

    [SerializeField] public AudioFile[] audioFiles;
    public AudioSource music;
    public AudioSource sfx;
    public AudioSource sfx2;
    public AudioSource sfx3;
    public AudioSource sfx4;
    public AudioSource sfx5;
    public AudioSource sfx6;
    public AudioSource sfx7;
    [Range(0, 1)] public float OverallVolume_Music;
    [Range(0, 1)] public float OverallVolume_SFX;
    [Range(0, 1)] public float OverallVolume_SFX2;
    [Range(0, 1)] public float OverallVolume_SFX3;
    [Range(0, 1)] public float OverallVolume_SFX4;
    [Range(0, 1)] public float OverallVolume_SFX5;
    [Range(0, 1)] public float OverallVolume_SFX6;
    [Range(0, 1)] public float OverallVolume_SFX7;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SetVolume();
    }
    public void SetVolume()
    {
            music.volume = instance.OverallVolume_Music;
            sfx.volume = instance.OverallVolume_SFX;
            sfx2.volume = instance.OverallVolume_SFX2;
            sfx3.volume = instance.OverallVolume_SFX3;
            sfx4.volume = instance.OverallVolume_SFX4;
            sfx5.volume = instance.OverallVolume_SFX5;
            sfx6.volume = instance.OverallVolume_SFX6;
            sfx7.volume = instance.OverallVolume_SFX7;
    }



    public void PlayMusic(string audioName)
    {
        var file = GetFileByName(audioName);

        if (file != null)
        {
            if (file.Clip != null)
            {
                music.clip = file.Clip;
                music.volume = instance.OverallVolume_Music;
                music.Play();
            }
            else Debug.LogError("This AudioFile does not have any AudioClip: " + audioName);
        }
        else Debug.LogError("Trying to play a sound that does not exist: " + audioName);
    }



    public void PlaySFX(string audioName)
    {
        var file = GetFileByName(audioName);

        if (file != null)
        {
            if (file.Clip != null)
            {
                sfx.clip = file.Clip;
                sfx.volume = instance.OverallVolume_SFX;
                sfx.Play();
            }
            else Debug.LogError("This AudioFile does not have any AudioClip: " + audioName);
        }
        else Debug.LogError("Trying to play a sound that not exist: " + audioName);
    }

    public void PlaySFX2(string audioName)
    {
        var file = GetFileByName(audioName);

        if (file != null)
        {
            if (file.Clip != null)
            {
                sfx2.clip = file.Clip;
                sfx2.volume = instance.OverallVolume_SFX2;
                sfx2.Play();
            }
            else Debug.LogError("This AudioFile does not have any AudioClip: " + audioName);
        }
        else Debug.LogError("Trying to play a sound that not exist: " + audioName);
    }

    public void PlaySFX3(string audioName)
    {
        var file = GetFileByName(audioName);

        if (file != null)
        {
            if (file.Clip != null)
            {
                sfx3.clip = file.Clip;
                sfx3.volume = instance.OverallVolume_SFX3;
                sfx3.Play();
            }
            else Debug.LogError("This AudioFile does not have any AudioClip: " + audioName);
        }
        else Debug.LogError("Trying to play a sound that not exist: " + audioName);
    }
    public void PlaySFX4(string audioName)
    {
        var file = GetFileByName(audioName);

        if (file != null)
        {
            if (file.Clip != null)
            {
                sfx4.clip = file.Clip;
                sfx4.volume = instance.OverallVolume_SFX4;
                sfx4.Play();
            }
            else Debug.LogError("This AudioFile does not have any AudioClip: " + audioName);
        }
        else Debug.LogError("Trying to play a sound that not exist: " + audioName);
    }
    public void PlaySFX5(string audioName)
    {
        var file = GetFileByName(audioName);

        if (file != null)
        {
            if (file.Clip != null)
            {
                sfx5.clip = file.Clip;
                sfx5.volume = instance.OverallVolume_SFX5;
                sfx5.Play();
            }
            else Debug.LogError("This AudioFile does not have any AudioClip: " + audioName);
        }
        else Debug.LogError("Trying to play a sound that not exist: " + audioName);
    }
    public void PlaySFX6(string audioName)
    {
        var file = GetFileByName(audioName);

        if (file != null)
        {
            if (file.Clip != null)
            {
                sfx6.clip = file.Clip;
                sfx6.volume = instance.OverallVolume_SFX6;
                sfx6.Play();
            }
            else Debug.LogError("This AudioFile does not have any AudioClip: " + audioName);
        }
        else Debug.LogError("Trying to play a sound that not exist: " + audioName);
    }

    public void PlaySFX7(string audioName)
    {
        var file = GetFileByName(audioName);

        if (file != null)
        {
            if (file.Clip != null)
            {
                sfx7.clip = file.Clip;
                sfx7.volume = instance.OverallVolume_SFX7;
                sfx7.Play();
            }
            else Debug.LogError("This AudioFile does not have any AudioClip: " + audioName);
        }
        else Debug.LogError("Trying to play a sound that not exist: " + audioName);
    }



    private AudioFile GetFileByName(string soundName)
    {
        var file = audioFiles.First(x => x.Name == soundName);
        if (file != null)
        {
            return file;
        }
        else Debug.LogError("Trying to play a sound that not exist: " + soundName);
    
        return null;

    }

    public void VolumeDown()
    {
        StartCoroutine(MusicVolumeDown());
    }

    private IEnumerator MusicVolumeDown()
    {
        float volumeSpeed = 0.005f;
        for (float i = music.volume; i >= music.volume/2.0f; i -= volumeSpeed)
        {
            music.volume = i;
            yield return null;
        }
        yield return null;
    }
}
