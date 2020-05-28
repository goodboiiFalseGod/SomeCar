using Client;
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
            GameObject[] victObjs = GameObject.FindGameObjectsWithTag("Alive");

            EcsEntity carEntity = _world.NewEntity();
            carEntity.Get<TransformRef>().value = carObj.transform;
            
            ref PhysicalBody physicalBody = ref carEntity.Get<PhysicalBody>();
            physicalBody.rigidbody = carObj.GetComponent<Rigidbody2D>();
            physicalBody.drag = 0.075f;
            
            ref Car car = ref carEntity.Get<Car>();
            car.forwardSpeed = 15f;
            car.backwardSpeed = 45f;
            car.turnSpeed = 2f;
            carEntity.Get<CarInput>();

            foreach(var victObj in victObjs)
            {
                EcsEntity victimEntity = _world.NewEntity();
                victimEntity.Get<TransformRef>().value = victObj.transform;

                ref PhysicalBody physBody = ref victimEntity.Get<PhysicalBody>();
                physBody.rigidbody = victObj.GetComponent<Rigidbody2D>();
                physBody.drag = 0.075f;

                ref VictimAIComponent victimAI = ref victimEntity.Get<VictimAIComponent>();
                victimAI.carDirection = Vector2.zero;
                victimAI.carDistance = 0;

                ref Victim victim = ref victimEntity.Get<Victim>();
                victim.health = 100;
            }          
        }
    }
}