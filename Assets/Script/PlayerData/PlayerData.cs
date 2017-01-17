using UnityEngine;

// This script will be passed over to the next scene to get the activeUser.
public class PlayerData : MonoBehaviour
{
    public string ActiveUser
    {
        get { return activeUser; }
        set { activeUser = value; }
    }
    [SerializeField]
    private string activeUser;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
    }
}