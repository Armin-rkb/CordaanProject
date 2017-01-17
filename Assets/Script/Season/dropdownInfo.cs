using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class dropdownInfo : MonoBehaviour {

	[SerializeField] private GameObject _dropdownObj;

	private Dropdown _infoDropdown;

	void Start()
	{
		_infoDropdown = _dropdownObj.GetComponent<Dropdown> ();

	}

	public int DropdownValue()
	{
		return _infoDropdown.value;
	}
}
