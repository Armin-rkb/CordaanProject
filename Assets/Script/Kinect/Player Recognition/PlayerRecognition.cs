using UnityEngine;
using System.Collections;

public class PlayerRecognition : MonoBehaviour
{
    [SerializeField]
    private KinectPointController kinectPointController;
    [SerializeField]
    private SkeletonWrapper skeletonWrapper;

    void Start()
    {
        StartCoroutine(CheckBoneDistance());
    }

    IEnumerator CheckBoneDistance()
    {
        while (true)
        {
            /*
            if (skeletonWrapper.trackedPlayers[skeletonWrapper.playerAmount] > 1)
                print("The Distance is: ");
            else
                print("No players");
            */
            yield return new WaitForSeconds(1);
        }
    }
}
