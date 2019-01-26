using AntonioHR.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AntonioHR.HomeColors
{

    public delegate void ScoreChangeCallback(int delta, int result);
    public class GameStateService : Service
    {
        public event ScoreChangeCallback ScoreChanged;


        private int score;

        public override void Init()
        {

        }

        public void GainedPickup()
        {
            score++;
            OnScoreChanged(1);
        }

        private void OnScoreChanged(int delta)
        {
            if (ScoreChanged != null)
                ScoreChanged(delta, score);
        }
    }
}