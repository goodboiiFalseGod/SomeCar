using Leopotam.Ecs;

namespace DefaultNamespace
{
    public class MoveCarSystem : IEcsRunSystem
    {
        private EcsFilter<TransformRef, PhysicalBody, Car, CarInput> _filter;


        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var transform = ref _filter.Get1(index);
                ref var physics = ref _filter.Get2(index);
                ref var car = ref _filter.Get3(index);
                ref var input = ref _filter.Get4(index);

                if (input.forward > 0)
                {
                    physics.rigidbody.AddForce(transform.value.up * car.forwardSpeed);
                }
                else if (input.forward < 0)
                {
                    physics.rigidbody.AddForce(-transform.value.up * car.backwardSpeed);
                }

                if (input.right != 0)
                {
                    physics.rigidbody.rotation -= input.right * car.rotationSpeed;
                }
                
            }
        }
    }
}