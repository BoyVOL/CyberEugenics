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
        /// <summary>
        /// Проверка операции DeleteAll, заполнение массивов элементами, первый не должен быть нулл. 
        /// Затем запуск метода и снова провека первого элемента. Он опять должен быть нулл.
        /// </summary>
        /// <returns></returns>
        public static bool TestDeleteAll(){
            ClassBufferArray<string> TestClass = new ClassBufferArray<string>(3);
            bool Result = true;
            //Переменная-буффер для значения AddNewItem
            bool buffer = false;
            TestClass.AddNewItem("10");
            TestClass.AddNewItem("10");
            TestClass.AddNewItem("10");
            buffer = TestClass.GetElement(0) == "10";
            Result &= (buffer);
            TestClass.DeleteAll();
            buffer = TestClass.GetElement(0) == null;
            Result &= (buffer);
            return Result;
        }
        /// <summary>
        /// Проверка GetElement на возвращение null. он должен вернуть это значение за границами массива, а так же за пределами индексов. 
        /// </summary>
        /// <returns></returns>
        public static bool TestGetElement(){
            ClassBufferArray<string> TestClass = new ClassBufferArray<string>(3);
            bool Result = true;
            //Переменная-буффер для значения AddNewItem
            bool buffer = false;
            TestClass.AddNewItem("10");
            TestClass.AddNewItem("10");
            TestClass.AddNewItem("10");
            buffer = TestClass.GetElement(0) == "10";
            Result &= (buffer);
            buffer = TestClass.GetElement(-1) == null;
            Result &= (buffer);
            buffer = TestClass.GetElement(4) == null;
            Result &= (buffer);
            TestClass.DeleteAll();
            buffer = TestClass.GetElement(0) == null;
            Result &= (buffer);
            return Result;
        }

        /// <summary>
        /// Общий тип тестов
        /// </summary>
        /// <returns></returns>
        public static bool RunTests(){
            bool Result = true;
            bool buffer = false;
            GD.Print("Проверка GetElement на возвращение null");
            buffer = TestGetElement();
            GD.Print("Результат = ",buffer);
            Result &= (buffer);
            GD.Print("Тест на добавление начального элемента в класс");
            buffer = TestOneElement();
            GD.Print("Результат = ",buffer);
            Result &= (buffer);
            GD.Print("Проверка GetLastIndex на отображение актуальной информации. Три раза добавляется элемент, и каждый раз проверяется значение.");
            buffer = TestGetLastIndexIncrement();
            GD.Print("Результат = ",buffer);
            Result &= (buffer);
            GD.Print("Проверка GetLastItem. Метод должен возвращать null до добавления элемента и 10 после");
            buffer = TestGetLastItemAddElement();
            GD.Print("Результат = ",buffer);
            Result &= (buffer);
            GD.Print("Проверка AddNewItem на переполнение.");
            buffer = TestAddNewItem();
            GD.Print("Результат = ",buffer);
            Result &= (buffer);
            GD.Print("Проверка операции DeleteAll.");
            buffer = TestDeleteAll();
            GD.Print("Результат = ",buffer);
            Result &= (buffer);
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
        bool buffer = false;
        GD.Print("------Тесты класса ClassBufferArray------");
        buffer = ClassBufferArrayTest.RunTests();
        GD.Print("------Тесты класса ClassBufferArray------");
        buffer = ClassBufferArrayTest.RunTests();
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
