/*!*************************************************************************
****
\file WASD.cs
\author Elton Teo
\par DP email: e.teo@digipen.edu
\par Course: csd3450
\date 28-1-2024
\brief  Script for controlling player and lockpick movement
****************************************************************************
***/
using ScriptAPI;
using System;

public class WASD : Script
{
    public override void Awake()
    {

    }
    public override void OnEnable()
    {

    }
    public override void Start()
    {

    }
    public override void Update()
    {
        if (Input.GetKeyDown(Keycode.W))
        {
            gameObject.GetComponent<RigidBodyComponent>().SetLinearVelocity(new Vector3(1000, 0, 0));
        }
        else if (Input.GetKeyDown(Keycode.S))
        {
            gameObject.GetComponent<RigidBodyComponent>().SetLinearVelocity(new Vector3(-1000, 0, 0));
        }
        else if (Input.GetKeyDown(Keycode.A))
        {
            gameObject.GetComponent<RigidBodyComponent>().SetLinearVelocity(new Vector3(0, -1000, 0));
        }
        else if (Input.GetKeyDown(Keycode.D))
        {
            gameObject.GetComponent<RigidBodyComponent>().SetLinearVelocity(new Vector3(0, 1000, 0));
        }
        else if (Input.GetKeyDown(Keycode.Q))
        {
            gameObject.GetComponent<RigidBodyComponent>().SetLinearVelocity(new Vector3(0, 0, -1000));
        }
        else if (Input.GetKeyDown(Keycode.E))
        {
            gameObject.GetComponent<RigidBodyComponent>().SetLinearVelocity(new Vector3(0, 0, 1000));
        }

        else
        {
            gameObject.GetComponent<RigidBodyComponent>().SetLinearVelocity(new Vector3(0, 0, 0));
        }
    }
    public override void LateUpdate()
    {

    }
    public override void OnDisable()
    {

    }
    public override void OnDestroy()
    {

    }
}