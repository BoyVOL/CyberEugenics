using Godot;
using System;

/// <summary>
/// Класс для создания и защищённого хранения фиксированного количества элементов заданного класса. 
/// Родительский класс для множества других дочерних.
/// </summary>
/// <typeparam name="T"></typeparam>
public class FixedBufferArray<T> where T : class, new(){
	/// <summary>
	/// Vассив объектов
	/// </summary>
	protected T[] Items;
	/// <summary>
	/// Конструктор без параметров. По умолчанию количество элементов 100
	/// </summary>
	public FixedBufferArray(){
		Items = new T[100];
		for (int i = 0; i < Items.Length; i++)
		{
			Items[i] = new T();
		}
	}
	/// <summary>
	/// Конструктор с параметром. Принимает целочисленное значение длины массива
	/// </summary>
	/// <param name="length">длина массива</param>
	public FixedBufferArray(int length){
		Items = new T[length];
		for (int i = 0; i < Items.Length; i++)
		{
			Items[i] = new T();
		}
	}
	/// <summary>
	/// Возврат длины внутреннего массива
	/// </summary>
	/// <returns>целочисленное значение длины</returns>
	public int getLength(){
		return Items.Length;
	}
}

/// <summary>
/// Объект-буффер для хранения предзагруженных спрайтов.
/// </summary>
public class SpriteBufferArray: FixedBufferArray<Sprite>{
	/// <summary>
	/// Перегрузка конструктора по умолчанию. Задаёт базовые параметры спрайта
	/// </summary>
	/// <returns></returns>
	public SpriteBufferArray() : base(){
		for (int i = 0; i < Items.Length; i++)
		{
			Items[i].Visible = false;
		}
	}
	/// <summary>
	/// Перегрузка конструктора с параметром длины массива. Задаёт базовые параметры спрайта
	/// </summary>
	/// <param name="length">длина массива</param>
	/// <returns></returns>
	public SpriteBufferArray(int length) : base(length){
		for (int i = 0; i < Items.Length; i++)
		{
			Items[i].Visible = false;
		}
	}
	/// <summary>
	/// Задание текстуры элемента
	/// </summary>
	/// <param name="i">индекс элемента</param>
	/// <param name="texture">текстура, которую надо загрузить спрайту</param>
	public void SetTexture(int i, Texture texture){
		Items[i].Texture = texture;
	}
	/// <summary>
	/// Метод задания текущих координат спрайта
	/// </summary>
	/// <param name="i">индекс спрайта</param>
	/// <param name="Coords">Координаты</param>
	public void SetCoordinates(int i, Vector2 Coords){
		Items[i].Position = Coords;
	}
	/// <summary>
	/// Метод задания видимости спрайта
	/// </summary>
	/// <param name="i">индекс спрайта</param>
	/// <param name="Visibility">Видимость</param>
	public void SetVisible(int i, bool Visibility){
		Items[i].Visible = Visibility;
	}
	/// <summary>
	/// Метод задания размеров спрайта
	/// </summary>
	/// <param name="i">индекс спрайта</param>
	/// <param name="Scale">Размеры</param>
	public void SetSize(int i, Vector2 Scale){
		Items[i].Scale = Scale;
	}
	/// <summary>
	/// Добавляет указанный элемент как ребёнок указанному экземпляру Node2D
	/// </summary>
	/// <param name="i">индекс элемента, который надо добавить</param>
	/// <param name="Parent">Новый Родитель</param>
	public void AddAsChild(int i, Node2D Parent){
		Parent.AddChild(Items[i]);
	}
	/// <summary>
	/// Удаляет выбранный элемент из списка детей выбранного экземпляра Node2D
	/// </summary>
	/// <param name="i">индекс элемента, которого надо удалить из списка детей старого родителя</param>
	/// <param name="Parent">Объект-родитель.</param>
	public void DeleteAsChild(int i, Node2D Parent){
		Parent.RemoveChild(Items[i]);
	}
}

/// <summary>
/// Класс для создания текстур из определённой палитры пикселей
/// </summary>
public class TextureConstructor{
	
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
/// Класс внешних элементов юнита.
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
	/// Конструктор по умолчанию
	/// </summary>
	public UnitElement(){
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
public class UnitWeapon : UnitElement
{
	/// <summary>
	/// Конструктор с параметром.
	/// </summary>
	/// <param name="Parent">Родитель класса</param>
	/// <returns></returns>
	public UnitWeapon() : base(){

	} 
}

/// <summary>
/// Класс колёс/ног/гусениц/прочих частей для движения юнита Класс предполагается часто клонировать вместо пересоздания.
/// </summary>
public class UnitChasis : UnitElement
{
	/// <summary>
	/// Конструктор с параметром.
	/// </summary>
	/// <param name="Parent">Родитель Класса</param>
	/// <returns></returns>
	public UnitChasis() : base(){

	}
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
	FixedBufferArray<UnitWeapon> Weapons = new FixedBufferArray<UnitWeapon>(10);
	/// <summary>
	/// Массив спрайтов шасси (частей для передвижения) юнита. По умолчанию все null;
	/// Размерность массива - 10
	/// </summary>
	FixedBufferArray<UnitChasis> Chasis = new FixedBufferArray<UnitChasis>(10);
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
