using Leopotam.Ecs;
using UnityEngine;

namespace DefaultNamespace
{
    public class CarInputSystem : IEcsRunSystem
    {
        private EcsFilter<CarInput> _filter;
        
        public void Run()
        {
            float forward = 0;
            float right = 0;

            if (Input.GetKey(KeyCode.W))
                forward = 1;
            else if (Input.GetKey(KeyCode.S))
                forward = -1;

            if (Input.GetKey(KeyCode.D))
                right = 1;
            else if (Input.GetKey(KeyCode.A))
                right = -1;

            foreach (var index in _filter)
            {
                ref var carInput = ref _filter.Get1(index);

                carInput.forward = forward;
                carInput.right = right;
            }
        }
    }
}