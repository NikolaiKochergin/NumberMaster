using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Source.Service.Input
{
    public interface IInputService
    {
         Vector2 Axis { get; }

         bool IsAttackButtonUp();
    }
}