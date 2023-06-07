using System.Linq;
using UnityEngine;

namespace _Project.Scripts.StaticData
{
    public enum RoadLineTypeId
    {
        Left = 0,
        Middle,
        Right
    }

    [System.Serializable]
    public class RoadLineData
    {
        [SerializeField] private RoadLineTypeId _typeId;
        [SerializeField] private float _offsetX;

        public RoadLineTypeId TypeId => _typeId;
        public float OffsetX => _offsetX;
    }
    
    [CreateAssetMenu(menuName = "StaticData/Level", fileName = "LevelStaticData")]
    public class LevelStaticData : ScriptableObject
    {
        [SerializeField] private RoadLineData[] _roadLineData;
        [SerializeField] private float _tilingOffsetZ;
        [SerializeField] private float _speed;
        [SerializeField] private int _maxRoadTiles;
        [SerializeField] private float _obstacleSpawningRate;

        public float TilingOffsetZ => _tilingOffsetZ;
        public float Speed => _speed;
        public int MaxRoadTiles => _maxRoadTiles;
        public float ObstacleSpawningRate => _obstacleSpawningRate;

        public RoadLineData GetRoadLineData(RoadLineTypeId typeId)
        {
            return _roadLineData.FirstOrDefault(x => x.TypeId == typeId);
        }
    }
}