using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    private static GameStateManager instance;
    public static GameStateManager Instance
    {
        get
        {
            if (instance == null)
                instance = FindAnyObjectByType<GameStateManager>();
            if (instance == null)
                instance = new GameObject(nameof(GameStateManager)).AddComponent<GameStateManager>();
            return instance;
        }
    }
    public enum GameState
    {
        InGame,
        OutGame,
    }
    private GameState state = GameState.InGame;
    public void InGame() => state = GameState.InGame;
    public void OutGame() => state = GameState.OutGame;
    public GameState GetState => state;
}
