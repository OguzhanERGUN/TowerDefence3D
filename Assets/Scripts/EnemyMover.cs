using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using static UnityEditor.Progress;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<WayPoint> path = new List<WayPoint>();
    [SerializeField] [Range(0f,5f)]float speedEnemy ;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FollowPath());


    }


    IEnumerator FollowPath()
    {
        foreach (WayPoint item in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = item.transform.position;
            float travelPercent = 0f;

            transform.LookAt(endPosition);
            while(travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * speedEnemy;
                transform.position = Vector3.Lerp(startPosition, endPosition,travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }
    }

}
