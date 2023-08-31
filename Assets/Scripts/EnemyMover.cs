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

    private Enemy enemy;
    
    
    
    private void Start()
    {
        enemy = GetComponent<Enemy>();    
    }
    
    
    
    void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
    }
    void FindPath()
    {
        path.Clear();

        GameObject[] waypoints = GameObject.FindGameObjectsWithTag("Path");

        foreach (GameObject waypoint in waypoints)
        {
            path.Add(waypoint.GetComponent<WayPoint>());
        }
    }

    private void ReturnToStart()
    {
        transform.position = path[0].transform.position;
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
        enemy.StealGold();

        gameObject.SetActive(false);
    }


}
