using Godot;
using System;
using UnitTesting;

/// <summary>
/// Пространство имён классов для модульного тестирования
/// </summary>
namespace UnitTesting{

}

public class UnitTests : Node
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
        #if DEBUG
        bool buffer = true;
        GD.Print("Результат всех тестов = ",buffer);
        if(!buffer){
            throw new Exception("auto tests found error");
        }
        #endif
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
