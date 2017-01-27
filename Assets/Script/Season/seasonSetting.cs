using UnityEngine;
using System.Collections;
using System.Runtime.Remoting.Channels;
using UnityEngine.Audio;

public class seasonSetting : MonoBehaviour {

	[SerializeField] private GameObject _dropdownInfo;

    [SerializeField] private AudioClip[] _audioClips;
    [SerializeField] private AudioSource _audiosource;
    private int _seasonNumber = 0;

    public delegate void SendSeasonNumber(int colorInt);
    public static event SendSeasonNumber OnSendSeason;



    public void Start()
    {
        _seasonNumber = _dropdownInfo.GetComponent<dropdownInfo>().DropdownValue();
	    switch (_seasonNumber)
	    {
            case 0: //Spring
                break;
            case 1: //summer
                _audiosource.PlayOneShot(_audioClips[1]);
                break;
            case 2: //autumn
                _audiosource.PlayOneShot(_audioClips[2]);
                break;
            case 3: //winter
                _audiosource.PlayOneShot(_audioClips[3]);
                break;
	    }
	}
}

