using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using static UnityEditor.Progress;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<WayPoint> path = new List<WayPoint>();
    float waitTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FollowPath());


    }


    IEnumerator FollowPath()
    {
        foreach (WayPoint item in path)
        {
            transform.position = item.transform.position;
            yield return new WaitForSeconds(waitTime);
        }
    }

}
