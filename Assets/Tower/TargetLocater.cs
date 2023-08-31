using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocater : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] float range = 15f;
    [SerializeField] ParticleSystem attackParticle;
    Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<Enemy>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        FindClosestTarget();
        AimUpdate();
    }

    private void FindClosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;
        foreach (Enemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if (targetDistance < maxDistance)
            {
                closestTarget = enemy.transform;
                maxDistance = targetDistance;
            
            }

            target = closestTarget;
        }
    }

    void AimUpdate()
    {
        float targetDistance = Vector3.Distance(transform.position, target.position);
        if (targetDistance < range)
        {
            Attack(true);
        }
        else
        {
            Attack(false);
        }
        weapon.LookAt(target);
    }


    void Attack(bool isActive)
    {
        var emissionModule = attackParticle.emission;
        emissionModule.enabled = isActive;
    }
}
