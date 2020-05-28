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
            
            ref PhysicalBody physicalBody = ref carEntity.Get<PhysicalBody>();
            physicalBody.rigidbody = carObj.GetComponent<Rigidbody2D>();
            physicalBody.drag = 0.075f;
            
            ref Car car = ref carEntity.Set<Car>();
            car.forwardSpeed = 65f;
            car.backwardSpeed = 45f;
            car.turnSpeed = 2f;
            carEntity.Get<CarInput>();
        }
    }
}