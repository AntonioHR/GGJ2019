using AntonioHR.HomeColors.PlayerBehaviours;
using AntonioHR.Services;
using Assets.AntonioHR.HomeColors;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AntonioHR.HomeColors
{

    public delegate void StatChangeCallback(int delta, int result);
    public class GameStateService : Service
    {
        public event StatChangeCallback ScoreChanged;
        public event StatChangeCallback HealthChanged;

        private int score = 1;
        public int Score { get { return score; } }
        private int health = 3;
        public int Health { get { return health; } }

        public Player CurrentPlayer { get; set; }
        public const int MaxHealth = 5;


        [SerializeField]
        private MoodColor startingColor;

        List<MoodColor> colors = new List<MoodColor>();

        public override void Init()
        {

            colors.Add(startingColor);
        }

        public void GainedPickup()
        {
            score++;
            if(health < MaxHealth)
            {
                PeformHealthChange(+1);
            }
            OnScoreChanged(1);
        }

        private void OnScoreChanged(int delta)
        {
            if (ScoreChanged != null)
                ScoreChanged(delta, score);
        }

        public bool PlayerHasColor(MoodColor moodColor)
        {
            return colors.Contains(moodColor);
        }

        public void OnPlayerTookDamage()
        {
            PeformHealthChange(-1);
        }

        private void PeformHealthChange(int change)
        {
            health += change;

            if (HealthChanged != null)
                HealthChanged(-1, health);

            if (health == 0)
            {
                OnDied();
            }
        }

        private void OnDied()
        {
            throw new NotImplementedException();
        }

        
    }
}