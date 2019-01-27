using AntonioHR.Services;
using DG.Tweening;
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
        [SerializeField]
        private TitleText title;

        private GameStateService gameStateService;
        private IngameScene scene;

        private void Start()
        {
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

        internal void Prepare(IngameScene ingameScene)
        {
            this.scene = ingameScene;

            gameStateService = ServiceManager.Get<GameStateService>();
            gameStateService.ScoreChanged += OnScoreChanged;
            SetScoreText(gameStateService.Score);
        }

        internal void Run()
        {
            title.Show(gameStateService.OnTitlePlayed);
        }
    }
}
