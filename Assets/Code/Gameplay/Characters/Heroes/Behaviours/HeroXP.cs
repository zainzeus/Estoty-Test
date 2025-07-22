using Code.Gameplay.Abilities.Behaviours;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class HeroXP : MonoBehaviour
{
    public int CurrentXP { get; private set; }
    public int Level { get; private set; }
    public event Action OnXPChanged;
    public event Action OnLevelUp;

    public void AddXP(int amount)
    {
        CurrentXP += amount;
        OnXPChanged?.Invoke();

        if (CurrentXP >= 10)
        {
            CurrentXP -= 10;
            Level++;
            OnXPChanged?.Invoke();
            OnLevelUp?.Invoke();
        }
    }
}
