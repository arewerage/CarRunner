using UnityEngine;

namespace _Project.Scripts.StaticData
{
    [CreateAssetMenu(menuName = "StaticData/Player", fileName = "PlayerStaticData")]
    public class PlayerStaticData : ScriptableObject
    {
        [SerializeField] private float _horizontalSlidingTime;

        public float HorizontalSlidingTime => _horizontalSlidingTime;
    }
}