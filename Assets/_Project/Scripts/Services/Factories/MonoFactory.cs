using UnityEngine;

namespace _Project.Scripts.Services.Factories
{
    public class MonoFactory<TMono> : IFactory<string, TMono>
        where TMono : Component
    {
        public TMono Create(string path)
        {
            TMono go = Resources.Load<TMono>(path);
            return Object.Instantiate(go);
        }
    }
}