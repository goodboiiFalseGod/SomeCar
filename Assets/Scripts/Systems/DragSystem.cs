using Leopotam.Ecs;
using Unity.Mathematics;
using UnityEngine;

namespace DefaultNamespace
{
    public class DragSystem : IEcsRunSystem
    {
        private EcsFilter<TransformRef, PhysicalBody> _filter;


        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var transform = ref _filter.Get1(index);
                ref var physics = ref _filter.Get2(index);

                var velocity = physics.rigidbody.velocity;

                float dragCoef = Vector2.Angle(math.abs((Vector2)transform.value.up), math.abs(velocity)) / 90 + 0.1f;

                if (math.abs(physics.rigidbody.velocity.x) > physics.drag)
                {
                    velocity.x -= math.sign(physics.rigidbody.velocity.x) * physics.drag * dragCoef;
                }
                else
                {
                    velocity.x /= 2;
                }
                
                if (math.abs(physics.rigidbody.velocity.y) > physics.drag)
                {
                    velocity.y -= math.sign(physics.rigidbody.velocity.y) * physics.drag * dragCoef;
                }
                else
                {
                    velocity.y /= 2;
                }

                physics.rigidbody.velocity = velocity;
            }
        }
    }
}