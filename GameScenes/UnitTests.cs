using Godot;
using System;
using UnitTesting;

/// <summary>
/// Пространство имён классов для модульного тестирования
/// </summary>
namespace UnitTesting{
    /// <summary>
    /// Тесты ClassBufferArray
    /// </summary>
    public class ClassBufferArrayTest{
        /// <summary>
        /// Тест на создание нового экземпляра
        /// </summary>
        /// <returns></returns>
        public static bool TestOneElement(){
            ClassBufferArray<string> TestClass = new ClassBufferArray<string>();
            TestClass.AddNewItem("10");
            if(TestClass.GetElement(0) == "10") return true;
            else return false;
        }
        /// <summary>
        /// Проверка GetLastIndex на отображение актуальной информации. Три раза добавляется элемент, и каждый раз проверяется значение.
        /// </summary>
        /// <returns></returns>
        public static bool TestGetLastIndexIncrement(){
            ClassBufferArray<string> TestClass = new ClassBufferArray<string>();
            bool Result = true;
            GD.Print(TestClass.GetLastIndex());
            Result &= (TestClass.GetLastIndex() == -1);
            TestClass.AddNewItem("10");
            GD.Print(TestClass.GetLastIndex());
            Result &= (TestClass.GetLastIndex() == 0);
            TestClass.AddNewItem("10");
            GD.Print(TestClass.GetLastIndex());
            Result &= (TestClass.GetLastIndex() == 1);
            TestClass.AddNewItem("10");
            GD.Print(TestClass.GetLastIndex());
            Result &= (TestClass.GetLastIndex() == 2);
            return Result;
        }
        /// <summary>
        /// Проверка GetLastItem. Метод должен возвращать null до добавления элемента и 10 после
        /// </summary>
        /// <returns></returns>
        public static bool TestGetLastItemAddElement(){
            ClassBufferArray<string> TestClass = new ClassBufferArray<string>();
            bool Result = true;
            GD.Print(TestClass.GetLastItem());
            Result &= (TestClass.GetLastItem() == null);
            TestClass.AddNewItem("10");
            GD.Print(TestClass.GetLastItem());
            Result &= (TestClass.GetLastItem() == "10");
            return Result;
        }
        /// <summary>
        /// Проверка AddNewItem на переполнение.
        /// </summary>
        /// <returns></returns>
        public static bool TestAddNewItem(){
            ClassBufferArray<string> TestClass = new ClassBufferArray<string>(3);
            bool Result = true;
            //Переменная-буффер для значения AddNewItem
            bool buffer = false;
            buffer = TestClass.AddNewItem("10");
            GD.Print(buffer);
            Result &= (buffer);
            buffer = TestClass.AddNewItem("10");
            buffer = TestClass.AddNewItem("10");
            buffer = TestClass.AddNewItem("10");
            GD.Print(buffer);
            Result &= (!buffer);
            return Result;
        }
    }
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
        GD.Print("Тест на добавление начального элемента в класс");
        GD.Print("Результат = ",ClassBufferArrayTest.TestOneElement());
        GD.Print("Проверка GetLastIndex на отображение актуальной информации. Три раза добавляется элемент, и каждый раз проверяется значение.");
        GD.Print("Результат = ",ClassBufferArrayTest.TestGetLastIndexIncrement());
        GD.Print("Проверка GetLastItem. Метод должен возвращать null до добавления элемента и 10 после");
        GD.Print("Результат = ",ClassBufferArrayTest.TestGetLastItemAddElement());
        GD.Print("Проверка AddNewItem на переполнение.");
        GD.Print("Результат = ",ClassBufferArrayTest.TestAddNewItem());
        #endif
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
