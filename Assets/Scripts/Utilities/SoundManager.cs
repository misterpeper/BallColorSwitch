using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Audio;


public class SoundManager : MonoBehaviour
{

    //Audio Sources
    public AudioSource sourceMusic, sourceSounds;

    //Instance
    public static SoundManager instance;

    //In-Game Sounds
    public AudioClip ButtonSound, Jump, Collision, Coin;

    //Soundtracks
    public AudioClip Soundtrack, GameOverSoundtrack, GameWinSoundtrack;

    //Volume parameters
    float CurrentSoundsVolume, CurrentMusicVolume;

    //Mixer groups
    public AudioMixer MasterMixer;

    //Sprites for buttons
    public Sprite[] MusicButton, SoundButton;
    public Image MusicImageStart;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    void Update()
    {
        MasterMixer.GetFloat("SoundsVolume", out CurrentSoundsVolume);
        MasterMixer.GetFloat("MusicVolume", out CurrentMusicVolume);
    }

    //Turn on and off sounds
    public void SoundVol()
    {
        if (CurrentSoundsVolume >= -15)
        {
            CurrentSoundsVolume = -80;
        }
        else if (CurrentSoundsVolume == -80)
        {
            CurrentSoundsVolume = -15;
        }
        MasterMixer.SetFloat("SoundsVolume", CurrentSoundsVolume);
    }

    //Turn on and off music
    public void MusicVol()
    {
        if (CurrentMusicVolume >= 0)
        {
            CurrentMusicVolume = -80;
            MusicImageStart.sprite = MusicButton[1];
        }
        else if (CurrentMusicVolume == -80)
        {
            CurrentMusicVolume = 0;
            MusicImageStart.sprite = MusicButton[0];
        }
        MasterMixer.SetFloat("MusicVolume", CurrentMusicVolume);
    }

    //Play sounds functions
    public void PlayJumpSound()
    {
        sourceSounds.PlayOneShot(Jump);
    }
    public void PlayCollisionSound()
    {
        sourceSounds.PlayOneShot(Collision);
    }
    public void PlayButtonSound()
    {
        sourceMusic.PlayOneShot(ButtonSound);
    }
    public void PlayCoinSound()
    {
        sourceSounds.PlayOneShot(Coin);
    }


    //Soundtracks

    //Intro Sountrack
    public void PlaySoundtrack()
    {
        StartCoroutine(PlayMainSoundtrack());
    }
    public IEnumerator PlayMainSoundtrack()
    {
        yield return new WaitForSeconds(0);
        sourceMusic.clip = Soundtrack;
        sourceMusic.loop = true;
        sourceMusic.Play();
    }
    //Game Over Sountrack
    public void GameOver()
    {
        StartCoroutine(PlayGameOverSoundtrack());
    }
    public IEnumerator PlayGameOverSoundtrack()
    {
        yield return new WaitForSeconds(0);
        sourceMusic.clip = GameOverSoundtrack;
        sourceMusic.loop = false;
        sourceMusic.Play();
    }
    //Game Over Sountrack
    public void GameWin()
    {
        StartCoroutine(PlayGameWinSoundtrack());
    }
    public IEnumerator PlayGameWinSoundtrack()
    {
        yield return new WaitForSeconds(0);
        sourceMusic.clip = GameWinSoundtrack;
        sourceMusic.loop = false;
        sourceMusic.Play();
    }
}
