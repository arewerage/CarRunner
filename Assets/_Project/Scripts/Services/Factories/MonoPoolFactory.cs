using UnityEngine;

namespace _Project.Scripts.Services.Factories
{
    public class MonoPoolFactory<TMono> : IFactory<TMono, Transform, TMono>
        where TMono : Component
    {
        public TMono Create(TMono prefab, Transform parent)
        {
            return Object.Instantiate(prefab, parent);
        }
    }
}