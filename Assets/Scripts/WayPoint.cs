using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] bool isPlaceable;


    [SerializeField] GameObject towerPrefab;
    public bool IsPlaceable { get { return isPlaceable; } }



    private void OnMouseDown()
    {
        if (isPlaceable)
        {
            Instantiate(towerPrefab,transform.position,towerPrefab.transform.rotation);
            isPlaceable = false;
        }
    }
}
