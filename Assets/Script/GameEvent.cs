using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GameEvent : MonoBehaviour
{
    private static GameEvent ins;
    public static GameEvent Instance
    {
        get
        {
            if (ins == null)
            {
                ins = FindAnyObjectByType<GameEvent>();
            }
            if (ins == null)
            {
                ins = new GameObject(nameof(GameEvent)).AddComponent<GameEvent>();
            }
            return ins;
        }
    }

    public Action 
        OnKillBall,
        OnBroken,
        OnBrokenAll,
        OnGameOver;
}
