﻿/*!*************************************************************************
****
\file blackboard.cs
\author Go Ruo Yan
\par DP email: ruoyan.go@digipen.edu
\par Course: csd3450
\date 26-02-2024
\brief  General information script for all other scripts
****************************************************************************
***/
using ScriptAPI;
using System;
using static DoorState;

public class GameBlackboard : Script
{
    public enum GameState
    {
        InGame,
        Lockpicking,
        Inventory,
        Paused
    }

    [DontSerializeField]
    [HideInInspector]
    public GameState gameState;
    [DontSerializeField]
    [HideInInspector]
    public GameState previousGameState;

    public enum DoorState
    {
        Locked,
        UnlockedOpen,
        UnlockedClosed,
        ForcedLock
    }

    [DontSerializeField]    
    [HideInInspector]
    public DoorState[] doorStates;

    public override void Awake()
    {
        doorStates = new DoorState[14];
        for (int i = 0; i < doorStates.Length; i++)
        {
            doorStates[i] = DoorState.Locked;
        }

        gameState = GameState.InGame;
    }

    public override void Update()
    {

        // Mouse cursor state
        switch (gameState)
        {
            case GameState.InGame:
                Input.Lock(true);
                Input.HideMouse(true);
                //Console.WriteLine("GameState.InGame");

                break;

            case GameState.Lockpicking:
                Input.Lock(false);
                Input.HideMouse(true);
                //Console.WriteLine("GameState.Lockpicking");

                break;

            case GameState.Inventory:
                Input.Lock(false);
                Input.HideMouse(false);
                //Console.WriteLine("GameState.Inventory");

                break;

            case GameState.Paused:
                Input.Lock(false);
                Input.HideMouse(false);
                //Console.WriteLine("GameState.Paused");

                break; 
        }
    }

    public override void LateUpdate()
    {
        previousGameState = gameState;
    }
}