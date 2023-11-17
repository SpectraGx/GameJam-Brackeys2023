using UnityEngine;


public class AudoManger : MonoBehaviour
{

    [Header("------------------Audio SFX------------")]
    [SerializeField] AudioSource MusicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("------------------Audio Sounds------------")]

    public AudioClip ExploBajoElAgua;
    public AudioClip GritoKraken;
    public AudioClip RomperCristal;
    public AudioClip SonidoTesoroBueno;
    public AudioClip SonidoTesoroMalo;
    public AudioClip SonidoClickMenu;

    [Header("------------------Audio Music------------")]

    public AudioClip SongMenu;
    public AudioClip SongZona1;
    public AudioClip SongZona2;
    public AudioClip SongJefe;

    private void Start()
    {
        MusicSource.clip = SongMenu;
        MusicSource.Play();
    }

    public void PlaySFX(AudioClip clip) 
    {
       

        SFXSource.PlayOneShot(clip);
    }


}
