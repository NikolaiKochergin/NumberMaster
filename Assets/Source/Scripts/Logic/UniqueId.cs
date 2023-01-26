﻿using System;
using UnityEngine;

namespace Source.Scripts.Logic
{
    public class UniqueId : MonoBehaviour
    {
        public string Id;

        public void GenerateId() => 
            Id = $"{gameObject.scene.name}_{Guid.NewGuid().ToString()}";
    }
}