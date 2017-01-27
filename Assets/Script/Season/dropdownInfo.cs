using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class dropdownInfo : MonoBehaviour {

    private int _randomSeasonNumber;

	public int DropdownValue()
	{
        return _randomSeasonNumber = Random.Range(0, 3);//_infoDropdown.value;
    }
}
