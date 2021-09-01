using Godot;
using System;

/// <summary>
/// Класс, который предоставляет доступ к массиву-буфферу классов. 
/// </summary>
public class ClassBufferArray<T> where T : class
{
    /// <summary>
    /// Массив классов. только для чтения
    /// </summary>
    public T[] Items
    {
        get;
    }
    /// <summary>
    /// Конструктор по умолчанию, заполняет массив стандартными значениями. Размер массива - 100;
    /// </summary>
    public ClassBufferArray(){
        Items = new T[100];
        for (int i = 0; i < Items.Length; i++)
        {
            Items[i] = null;
        }
    }
    /// <summary>
    /// Конструктор с заданием размера массива, заполняет массив стандартными значениями.
    /// </summary>
    public ClassBufferArray(int Size){
        if(Size >= 0){
            Items = new T[Size];
            for (int i = 0; i < Items.Length; i++)
            {
                Items[i] = null;
            }
        } else throw new Exception("Size of array could not be negative");
    }
    /// <summary>
    /// Поиск последнего ненулевого элемента в массиве. Возвращает индекс найденного элемента, или -1, если весь массив null
    /// </summary>
    /// <returns>индекс найденного элемента, или -1, если весь массив нулл</returns>
    public int GetLastIndex(){
        //Если начальный элемент нулл - массив пуст.
        if (Items[0] == null) return -1;
        //если нет - ищем первый нулл элемент
        for (int i = 0; i < Items.Length; i++)
        {
            //Нашли, возвращаем элемент перед ним.
            if (Items[i] == null){
                return i-1;
            }
        }
        //Не нашли - возвращаем последний.
        return Items.Length-1;
    }

    /// <summary>
    /// Возвращает последний элемент в массиве или null, если ничего не задано.
    /// </summary>
    /// <returns></returns>
    public T GetLastItem(){
        int id = GetLastIndex();
        //Проверка положительность индекса.
        if(id < 0){
            return null;
        } else {
            return Items[id];
        }
    }

    /// <summary>
    /// Добавление нового элемента. Возвращает true, если удалось добавить, и false в противном случае.
    /// </summary>
    /// <param name="newItem"></param>
    /// <returns></returns>
    public bool AddNewItem(T newItem){
        int id = GetLastIndex();
        //Проверка на то, что массив уже заполнен
        if(id <= Items.Length-1){
            //Проверка на то, что индекс больше нуля (То есть функция не вернула пустой результат)
            if (id >= 0){
                Items[id+1] = newItem;
            }
            else{
                Items[0] = newItem;
            }
            return true;
        } else {
            return false;
        }
    }
    
    /// <summary>
    /// Присвоение null последнему ненулевому элементу, если таковой задан;
    /// </summary>
    public void DeleteItem(){
        int id = GetLastIndex();
        if(id >= 0){
            Items[id] = null;
        }
    }
    /// <summary>
    /// Присвоение null всем элементам массива
    /// </summary>
    public void DeleteAll(){
        int length = GetLastIndex();
        if(length >= 0){
            for (int i = 0; i < length; i++)
            {
                Items[i] = null;
            }
        }
    }

    /// <summary>
    /// Возврат элемента по нужному индексу. Возвращает null, если индекс пустой и индекс за границей массива.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public T GetElement(int id){
        if(id < Items.Length){
            return Items[id];
        } else {
            return null;
        }
    }
}
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

/// <summary>
/// Класс внешних элементов юнитов.
/// </summary>
public class UnitElement{
    /// <summary>
    /// Спрайт элемента. По умолчанию null. Предполагается задавать его извне, чтобы не загружать процесс созданием нового класса.
    /// </summary>
    public Sprite ElementSprite = null;

    /// <summary>
    /// Ссылка на родителя элемента
    /// </summary>
    Unit Parent = null;
    /// <summary>
    /// Положение элемента относительно родителя
    /// </summary>
    /// <returns></returns>
    public Vector2 shift = new Vector2(0,0);
    /// <summary>
    /// Угол поворота элемента относительно родителя
    /// </summary>
    public float Angle = 0;
    /// <summary>
    /// Конструктор с параметром, в котором указывается родительский экземпляр орудия
    /// </summary>
    /// <param name="parent">Родительский экземпляр объекта</param>
    public UnitElement(Unit parent){
        Parent = parent;
    }
    /// <summary>
    /// Метод обновления параметров спрайта. 
    /// </summary>
    public void UpdateSprite(){
        if (ElementSprite != null)
        {
            if (Parent != null)
            {
                
            } else throw new Exception("Parent is not set");
        } else throw new Exception("Sprite is not set");
    }
}
/// <summary>
/// Класс оружия юнита. Класс предполагается часто клонировать вместо пересоздания.
/// </summary>
public class UnitWeapon
{
    
}
/// <summary>
/// Класс колёс/ног/гусениц/прочих частей для движения юнита Класс предполагается часто клонировать вместо пересоздания.
/// </summary>
public class UnitChasis
{
    /// <summary>
    /// Спрайт шавсси. По умолчанию null. Предполагается задавать его извне, чтобы не загружать процесс созданием нового класса. 
    /// </summary>
    Sprite ChasisSprite = null;
}
/// <summary>
/// Класс подконтрольного юнита. Содержит в себе методы для обработки его состояния и поведения. Класс предполагается часто клонировать вместо пересоздания.
/// </summary>
public class Unit 
{
    /// <summary>
    /// Спрайт тела юнита. По умолчанию null. Предполагается задавать его извне, чтобы не загружать процесс созданием нового класса.
    /// </summary>
    Sprite BodySprite = null;
    /// <summary>
    /// Массив пушек юнита. 
    /// Максимальная размерность 10. По умолчанию все null;
    /// </summary>
    ClassBufferArray<UnitWeapon> Weapons = new ClassBufferArray<UnitWeapon>(10);
    /// <summary>
    /// Массив спрайтов шасси (частей для передвижения) юнита. По умолчанию все null;
    /// Размерность массива - 10
    /// </summary>
    ClassBufferArray<UnitChasis> Chasis = new ClassBufferArray<UnitChasis>(10);
    /// <summary>
    /// Положение объекта на игровом поле. По умолчанию 0,0.
    /// </summary>
    Vector2 Position = new Vector2(0,0);
    /// <summary>
    /// Угол поворота тела в радианах. По умолчанию 0.
    /// </summary>
    float Rotation = 0;
    /// <summary>
    /// Конструктор по умолчанию. В нём мы задаём начальные значения переменным.
    /// </summary>
    public Unit(){
    }
   
}

public class LibLoader : Node
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {

    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
