using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    public enum GameState { MENU, GAME, PAUSE, ENDGAME };

    public GameState gameState { get; private set; }
    public int health;
    public int pontos;
    private static GameManager _instance;

    public delegate void ChangeStateDelegate();
    public static ChangeStateDelegate changeStateDelegate;


    public static GameManager GetInstance()
    {
        if (_instance == null)
        {
            _instance = new GameManager();
        }

        return _instance;
    }
    private GameManager()
    {
        health = 10;
        pontos = 0;
        // print("construtor");
        gameState = GameState.MENU;
    }
    public void ChangeState(GameState nextState)
    {
        if (nextState == GameState.GAME) Reset();
        gameState = nextState;
        changeStateDelegate();
    }
    private void Reset()
    {
        health = 10;
        pontos = 0;
    }

}