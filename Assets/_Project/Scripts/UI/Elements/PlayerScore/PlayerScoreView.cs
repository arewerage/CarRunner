using TMPro;
using UnityEngine;

namespace _Project.Scripts.UI.Elements.PlayerScore
{
    public class PlayerScoreView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _scoreText;

        public TMP_Text ScoreText => _scoreText;
    }
}