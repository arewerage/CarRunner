using _Project.Scripts.ECS.Common.Collisions;
using Scellecs.Morpeh;
using UnityEngine;

namespace _Project.Scripts.ECS.UnityComponents
{
    public class CollisionDetector : MonoBehaviour
    {
        private World _world;

        public Entity Entity { get; private set; }

        public void Initialize(World world, Entity entity)
        {
            _world = world;
            Entity = entity;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            CollisionDetector detector = other.GetComponent<CollisionDetector>();

            _world.CreateEntity().SetComponent(new TriggerEvent
            {
                Self = Entity,
                Other = detector ? detector.Entity : null
            });
        }
    }
}