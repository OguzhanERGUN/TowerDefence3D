using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;

    [Tooltip("düþman öldüðünde maksimum can miktarýný arttýrýr")]
    [SerializeField] int difficultyRamp;


    int currentHitPoint = 0;

    Enemy enemy;
    // Start is called before the first frame update
    void OnEnable()
    {
        currentHitPoint  = maxHitPoints;
    }
    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("particle temas etti");
        ProcessHit();
    }



    void ProcessHit()
    {
        currentHitPoint--;

        if (currentHitPoint <= 0)
        {
            gameObject.SetActive(false);
            maxHitPoints += difficultyRamp;
            enemy.RewardGold();
        }
    }
}
