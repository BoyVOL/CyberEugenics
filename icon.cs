using Godot;
using System;

public class icon : Sprite
{
/// <summary>
/// Класс проверки многопоточности и взаимодействия скриптов
/// </summary>
public class TestClass {
	/// <summary> Поле данных 1 </summary>
	public int data1 = 0;
	/// <summary> Поле данных 1 </summary>
	public int data2 = 0;
	/// <summary>
	/// Поле данных 3
	/// </summary>
	public int data3 = 0;
	/// <summary>
	/// Метод изменения данных 1. Увеличивает поле на 1 и спит на секунду.
	/// </summary>
	public void ChangeData1(){
		data1 ++;
		System.Threading.Thread.Sleep(100);
		GD.Print("Data1 = "+data1.ToString());
	}
   /// <summary>
	/// Метод изменения данных 2. Увеличивает поле на 1 и спит на секунду.
	/// </summary>
	public void ChangeData2(){
		data2 ++;
		System.Threading.Thread.Sleep(100);
		GD.Print("Data2 = "+data2.ToString());
	}
   /// <summary>
	/// Метод изменения данных 3. Увеличивает поле на 1 и спит на секунду.
	/// </summary>
	public void ChangeData3(){
		data3 ++;
		System.Threading.Thread.Sleep(1000);
		GD.Print("Data3 = "+data3.ToString());
	}
}

    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        GD.Print("BLA");
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
