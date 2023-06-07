using System.Collections.Generic;
using _Project.Scripts.Services.Factories;
using UnityEngine;

namespace _Project.Scripts.Services.Pools
{
    public class ObjectPool<T> where T : Component
    {
        private readonly IFactory<T, Transform, T> _factory;
        private readonly int _size;
        private readonly string _containerName;
        private readonly T[] _prefabs;
        
        private Queue<T> _pool;
        private Transform _container;

        public bool HasElements => _pool.Count > 0;

        public ObjectPool(IFactory<T, Transform, T> factory, PoolData<T> poolData)
        {
            _factory = factory;
            _size = poolData.Size;
            _prefabs = poolData.Prefabs;
            _containerName = poolData.ContainerName;
        }

        public void Initialize()
        {
            _pool = new Queue<T>(_size);
            _container = new GameObject(_containerName).transform;
            
            for (int i = 0; i < _size; i++)
                CreateElementInPool(_prefabs[Random.Range(0, _prefabs.Length)]);
        }

        private void CreateElementInPool(T element)
        {
            T obj =_factory.Create(element, _container);
            ReturnElement(obj);
        }

        public T GetElement()
        {
            if (_pool.Count == 0)
                CreateElementInPool(_prefabs[Random.Range(0, _prefabs.Length)]);

            T element =  _pool.Dequeue();
            element.gameObject.SetActive(true);
            return element;
        }

        public void ReturnElement(T element, bool isInitialPosition = false)
        {
            if (element.transform.parent != _container)
                element.transform.SetParent(_container);
            
            element.gameObject.SetActive(false);
            
            if (isInitialPosition)
                element.transform.localPosition = Vector3.zero;
            
            _pool.Enqueue(element);
        }
    }
}