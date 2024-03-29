﻿using System;
using UnityEngine;

namespace Source.Scripts.Data
{
    [Serializable]
    public class PlayerProgress
    {
        public State PlayerState;
        public Stats PlayerStats;
        public Soft Soft;
        public World World;
        public GameSettings GameSettings;
        public PurchaseData PurchaseData;

        public PlayerProgress()
        {
            PlayerState = new State();
            PlayerStats = new Stats();
            Soft = new Soft();
            World = new World();
            GameSettings = new GameSettings();
            PurchaseData = new PurchaseData();

            if (PurchaseData.AnotherPurchases.Contains(135))
                Debug.Log("eeeee");
        }
    }
}