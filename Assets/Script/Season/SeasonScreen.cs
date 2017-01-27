using UnityEngine;
using System.Collections;

public class SeasonScreen : MonoBehaviour {

    [SerializeField]
    private GameObject _dropdownInfo;

    [SerializeField] private Sprite[] _seasonSprites;
    private int _seasonNumber;

    void Start()
    {

        switch (_dropdownInfo.GetComponent<dropdownInfo>().DropdownValue())
        {
            case 0: //Spring
                GetComponent<SpriteRenderer>().sprite = _seasonSprites[0];
                break;
            case 1: //summer
                GetComponent<SpriteRenderer>().sprite = _seasonSprites[1];
                break;
            case 2: //autumn
                GetComponent<SpriteRenderer>().sprite = _seasonSprites[2];
                break;
            case 3: //winter
                GetComponent<SpriteRenderer>().sprite = _seasonSprites[3];
                break;

        }
    }
}

