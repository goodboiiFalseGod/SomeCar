using Leopotam.Ecs;
using UnityEngine;

namespace Client {
    sealed class VictimDamaginSystem : IEcsRunSystem {
        // auto-injected fields.
        readonly EcsWorld _world = null;

        private EcsFilter<Victim, DamagedFlag> _filter;

        void IEcsRunSystem.Run () {
            // add your run code here.
            foreach(var index in _filter)
            {
                ref Victim victim = ref _filter.Get1(index);
                victim.health -= (int)_filter.Get2(index).damage;
                Debug.Log(victim.health);

                _filter.GetEntity(index).Del<DamagedFlag>();
            }
        }
    }
}