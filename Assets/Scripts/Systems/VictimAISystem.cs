using DefaultNamespace;
using JetBrains.Annotations;
using Leopotam.Ecs;
using Unity.Mathematics;
using UnityEngine;

namespace Client {
    sealed class VictimAISystem : IEcsRunSystem {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        private readonly GameData _gameData;

        private EcsFilter<VictimAIComponent, TransformRef, PhysicalBody> _filter;
        private EcsFilter<TransformRef, Car> _filter2;

        /*void IEcsRunSystem.Run () {
            // add your run code here.
            float dis;
            Vector2 dir;

            foreach (var index in _filter)
            {
                ref var ai = ref _filter.Get1(index);
                ref var transform = ref _filter.Get2(index);
                ref var physical = ref _filter.Get3(index);

                foreach (var index2 in _filter2)
                {
                    dis = Vector2.Distance(transform.value.position, _filter2.Get1(index2).value.position);                    
                    dir = GetDir(transform.value.position, _filter2.Get1(index2).value.position);

                    if (dis < 5)
                    {
                        physical.rigidbody.AddForce(-dir * 1.4f);
                    }
                }
            }
        }*/

        void IEcsRunSystem.Run()
        {
            // add your run code here.
            float dis;
            Vector2 dir;

            foreach (var index in _filter)
            {
                ref var ai = ref _filter.Get1(index);
                ref var transform = ref _filter.Get2(index);
                ref var physical = ref _filter.Get3(index);

                RaycastHit2D[] raycasts = Physics2D.CircleCastAll(transform.value.position, 10, Vector2.zero);

                dis = raycasts[0].distance;
                dir = raycasts[0].normal;

                foreach (var raycast in raycasts)
                {
                    Debug.Log(dis);
                    Debug.Log(dir);

                    if (raycast.distance > dis & raycast.distance != 0)
                    {
                        dis = raycast.distance;
                        dir = raycast.normal;
                    }
                }

                if (dis < 5)
                {
                    physical.rigidbody.AddForce(dir * 1.4f);
                }
            }

        }

        private Vector2 GetDir(Vector2 v1, Vector2 v2)
        {
            Vector2 dir = (v2 - v1).normalized;
            return dir;
        }

        
        //[CanBeNull]
        private Vector3[] FindAllObstacles(Vector3 position, float radius, LayerMask whatIsObstacle)
        {
            RaycastHit2D[] hits = Physics2D.CircleCastAll(position, radius, Vector2.zero, 0f, whatIsObstacle);
            Vector3[] points = new Vector3[hits.Length];

            for (int i = 0; i < hits.Length; i++)
            {
                points[i] = hits[i].point;
            }

            return points;
        }
    }
}