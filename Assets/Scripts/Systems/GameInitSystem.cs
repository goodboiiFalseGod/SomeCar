using Leopotam.Ecs;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameInitSystem : IEcsInitSystem
    {
        private EcsWorld _world;
        
        public void Init()
        {
            GameObject carObj = GameObject.FindWithTag("Player");

            EcsEntity carEntity = _world.NewEntity();
            carEntity.Get<TransformRef>().value = carObj.transform;
            carEntity.Get<PhysicalBody>().rigidbody = carObj.GetComponent<Rigidbody2D>();
            ref Car car = ref carEntity.Set<Car>();
            car.forwardSpeed = 6.5f;
            car.backwardSpeed = 4.5f;
            car.rotationSpeed = 0.3f;
            carEntity.Get<CarInput>();
        }
    }
}