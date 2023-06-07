using UnityEngine;

namespace _Project.Scripts.Mono
{
    public class PlayerEntityView : EntityViewBase
    {
        [SerializeField] private Rigidbody _body;

        public Rigidbody Body => _body;
    }
}