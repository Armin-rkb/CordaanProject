using UnityEngine;
using System.Collections;

public class Colors : MonoBehaviour {

    [SerializeField]
    private GameObject _summerParticles;
    [SerializeField]
    private GameObject _winterParticles;
    [SerializeField]
    private GameObject _autumnParticles;

    void Start()
    {
       // seasonSetting.OnSendSeason += ChangeColors;
    }
    void ChangeColors(int colorCode)
    {
        switch (colorCode)
        {
            case 0: //spring
                EnableParticles(_summerParticles, _autumnParticles, _winterParticles);
                break;
            case 1: //summer
                EnableParticles(_summerParticles, _autumnParticles, _winterParticles);
                break;
            case 2: //autumn
                EnableParticles(_autumnParticles, _summerParticles, _winterParticles);
                break;
            case 3: //winter
                EnableParticles(_winterParticles, _autumnParticles, _summerParticles);
                break;

        }
    }

    void EnableParticles(GameObject enabled, GameObject disabled_1, GameObject disabled_2)
    {
        enabled.SetActive(true);
        disabled_1.SetActive(false);
        disabled_2.SetActive(false);

    }
}
