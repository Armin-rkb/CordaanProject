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



    public void UpdateSeasonColor()
    {
        _seasonNumber = _dropdownInfo.GetComponent<dropdownInfo>().DropdownValue();
	    switch (_seasonNumber)
	    {
            case 0: //Spring
                print("Spring");
                _audiosource.PlayOneShot(_audioClips[0]);
                // OnSendSeason(_seasonNumber);
                break;
            case 1: //summer
                print("Summer");
                _audiosource.PlayOneShot(_audioClips[1]);
                //  OnSendSeason(_seasonNumber);
                break;
            case 2: //autumn
                print("Autumn");
                _audiosource.PlayOneShot(_audioClips[2]);
                // OnSendSeason(_seasonNumber);
                break;
            case 3: //winter
                print("Winter");
                _audiosource.PlayOneShot(_audioClips[3]);
                // OnSendSeason(_seasonNumber);
                break;
                
	    }
	}
}

