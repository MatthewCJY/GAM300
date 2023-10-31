﻿using ScriptAPI;
using System;
using System.Threading.Tasks;

public class Testing : Script
{
    [SerializeField]
    public bool hihi = true;
}

public class Test : Script
{
    [SerializeField]
    public GameObject gameObjectTest;

    [SerializeField]
    public Testing scriptTest;
    
    [SerializeField]
    public String stringTest;

    [SerializeField]
    private bool boolTest = false;

    [SerializeField]
    private double doubleTest;

    [SerializeField]
    private int intTest;

    [SerializeField]
    private float floatTest;

    public override void Awake() 
    {
        //otherEntity = GameObjectScriptFind("entity3");
        //Console.WriteLine(otherEntity);
        //otherEntity.GetComponent<TransformComponent>().SetPositionX(20);
        //Console.WriteLine(script.gameObject);
        //gameObject.GetTransformComponent();
    }

    public override void OnEnable() 
    {
        Console.WriteLine("Enabled");
        ExampleAsync();
    }

    public override void Start()
    {
        Console.WriteLine("Start Test");
    }

    public override void Update()
    {
        //Console.WriteLine("Aye Lmao");
        gameObject.GetComponent<TransformComponent>().SetPositionX(3);
        //TransformComponent tf = gameObject.GetTransformComponent();
        //tf.SetPositionX(3.0f);
    }

    public override void LateUpdate() { }

    public override void OnDisable() 
    {
        Console.WriteLine("Disabled");
    }

    public override void OnDestroy() 
    {
        Console.WriteLine("Exit");
    }


    // Example Usecase (Coroutine Example)
    public async IAsyncEnumerable<int> MyCoroutineAsync()
    {
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("Coroutine step " + i);
            await Task.Delay(1000); // Simulate some work asynchronously
            yield return i;
        }
    }

    // Example Usecase
    async Task<int> ExampleAsync()
    {
        Console.WriteLine("Starting Unity Coroutine with IEnumerable result");

        await foreach (var value in Coroutine(() => MyCoroutineAsync(), 1000))
        {
            Console.WriteLine("Yielded Value: " + value);
        }

        Console.WriteLine("Unity Coroutine finished");

        return 0;
    }
}
