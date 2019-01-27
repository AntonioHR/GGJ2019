using AntonioHR.HomeColors.Interactables;
using AntonioHR.HomeColors.PlayerBehaviours;
using AntonioHR.Services;
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
        public event Action GameWon;

        public event Action<MoodColor> PlayerGainedColor;


        private int startingHealth = 3;

        private int score = 1;
        public int Score { get { return score; } }


        private int health;
        public int Health { get { return health; } }

        public Player CurrentPlayer { get; set; }
        public const int MaxHealth = 5;


        [SerializeField]
        private MoodColor startingColor;

        List<MoodColor> colors = new List<MoodColor>();
        private Checkpoint lastCheckpoint;

        public override void Init()
        {
            health = startingHealth;

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

        public void OnPlayerGainedColor(MoodColor givenColor)
        {
            colors.Add(givenColor);
            if (PlayerGainedColor != null)
                PlayerGainedColor(givenColor);


        }

        internal void OnTitlePlayed()
        {
            CurrentPlayer.Unsnap();
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
            health = 0;
            PeformHealthChange(startingHealth);

            CurrentPlayer.OnDied();
            CurrentPlayer.ResetToCheckpoint(lastCheckpoint);
        }

        public void RegisterCheckpoint(Checkpoint checkpoint)
        {
            Debug.Assert(checkpoint != null);
            lastCheckpoint = checkpoint;
        }

        [NaughtyAttributes.Button]
        private void GainBlue()
        {
            OnPlayerGainedColor(MoodColor.Blue);
        }


        [NaughtyAttributes.Button]
        private void GainYellow()
        {
            OnPlayerGainedColor(MoodColor.Yellow);
        }



        internal void OnGameWon()
        {
            if (GameWon != null)
                GameWon();
        }
    }
}