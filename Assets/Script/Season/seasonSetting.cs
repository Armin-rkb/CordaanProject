using UnityEngine;
using System.Collections;

public class seasonSetting : MonoBehaviour {

	[SerializeField] private GameObject _dropdownInfo;

    public delegate void SendSeasonNumber(int colorInt);
    public static event SendSeasonNumber OnSendSeason;

	public void UpdateSeasonColor()
	{
		int colorInt = 0;

		colorInt = _dropdownInfo.GetComponent<dropdownInfo> ().DropdownValue ();

        OnSendSeason(colorInt);
	}
}

