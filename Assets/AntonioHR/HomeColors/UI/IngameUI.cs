using AntonioHR.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace AntonioHR.HomeColors.UI
{
    public class IngameUI : MonoBehaviour
    {

        [SerializeField]
        private Text scoreText;

        private GameStateService gameStateService;


        private void Start()
        {
            gameStateService = ServiceManager.Get<GameStateService>();
            gameStateService.ScoreChanged += OnScoreChanged;
            SetScoreText(gameStateService.Score);
        }
        private void OnDestroy()
        {
            gameStateService.ScoreChanged -= OnScoreChanged;
        }

        private void OnScoreChanged(int delta, int result)
        {
            SetScoreText(result);
        }

        private void SetScoreText(int result)
        {
            scoreText.text = result.ToString();
        }
    }
}
