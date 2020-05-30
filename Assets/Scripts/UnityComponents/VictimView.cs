using System.Collections;
using System.Collections.Generic;
using Client;
using Leopotam.Ecs;
using UnityEngine;

public class VictimView : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector]
    public EcsEntity _victimEntity;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float p = collision.relativeVelocity.magnitude;

        ref DamagedFlag damagedFlag = ref _victimEntity.Get<DamagedFlag>();
        damagedFlag.damage = p;
    }
}
