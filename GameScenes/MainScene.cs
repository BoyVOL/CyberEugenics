using Godot;
using System;
using System.Threading.Tasks;

public class MainScene : Node2D
{
	/// <summary>
	/// Тестовая текстура
	/// </summary>
	Texture TestTexture;
	/// <summary>
	/// Объект рандомного генератора
	/// </summary>
	/// <returns></returns>
	Random Rnd = new Random();
	/// <summary>
	/// ТЕстовый буффер
	/// </summary>
	SpriteBufferArray Buffer = new SpriteBufferArray(1000);
	/// <summary>
	/// Тестовый конструктор текстур
	/// </summary>
	/// <returns></returns>
	TextureEditor Builder = new TextureEditor(50);
	/// <summary>
	/// Задание тестового экземпляра конструктора текстур и его элементов
	/// </summary>
	public void SetTestConstructor(){

	}
	/// <summary>
	/// Метод для задания начальной точки тестового буффера
	/// </summary>
	public void SetSpritesForTest(){
		Builder.ClearTexture();
		Builder.Lock();
		Builder.SetPixel(0,0,Colors.Red);
		Builder.SetPixel(5,5,Colors.Red);
		Builder.SetPixel(10,10,Colors.Red);
		Builder.Unlock();
		TestTexture = ResourceLoader.Load<Texture>("res://EnemyMiner.png");
		for (int i = 0; i < Buffer.getLength(); i++)
		{
			Buffer.SetSize(i,new Vector2(1,1));
			Buffer.SetTexture(i, Builder.GetTexture());
			Buffer.SetCoordinates(i, new Vector2((float)Rnd.NextDouble()*1000,(float)Rnd.NextDouble()*1000));
			Buffer.SetVisible(i,true);
			Buffer.AddAsChild(i,this);
		}
	}
	/// <summary>
	/// Метод тестирования функционала словаря, который предоставляется движком
	/// </summary>
	public void TestDictionary(){
		Godot.Collections.Dictionary<int,string> TestDict = new Godot.Collections.Dictionary<int,string>();
		for (int i = 0; i < 10000; i++)
		{
			TestDict.Add(i,"test");
		}
		string Result;
		TestDict.TryGetValue(1,out Result);
		//GD.Print("Результат теста словаря = ", Result);
	}
	/// <summary>
	/// Проверка быстродействия и возможностей системного класса шеш таблицы
	/// </summary>
	public void TestSysHashTable(){
		System.Collections.Hashtable Hash = new System.Collections.Hashtable();
		System.Collections.Queue test = new System.Collections.Queue();
		for (float i = 0; i < 100000; i++)
		{
			Hash.Add(i,test);
		}
		//string Result;
		//Result = (string)Hash[0];
		//GD.Print("Результат теста хеш-таблицы] = ", Result);
	}
	/// <summary>
	/// Метод для проверки создания и редактирования изображений
	/// </summary>
	public void TestImageGeneration(){
		for (int k = 0; k < 10; k++)
		{
			Image Test = new Image();
			Test.Create(100,100,true,Image.Format.Rgb8);
			Test.Lock();
			for (int i = 0; i < 50; i++)
			{
				for (int j = 0; j < 50; j++)
				{
					Test.SetPixel(i,j,Colors.Red);
				}
			}
			Test.Unlock();
		}
	}
	/// <summary>
	/// Метод проверки многопоточной обработки изображений
	/// </summary>
	public void TestMultitreading(){
		System.Threading.Thread[] Threads = new System.Threading.Thread[10];
		for (int i = 0; i < 5; i++)
		{
			Threads[i] = new System.Threading.Thread(TestImageGeneration);
			Threads[i].Start();
		}
		for (int i = 0; i < 10; i++)
		{
			Threads[i].Join();
		}
	}
	/// <summary>
	/// Метод для тестирования класса PosQueueTable
	/// </summary>
	public void TestPosQueueTable(){
		PosQueueTable<string> Test = new PosQueueTable<string>();
		Test.InitRange(-100,100,-100,100);
		GD.Print(Test.Exists(99,99));
	}
	/// <summary>
	/// Функция обновления тестового массива спрайтов
	/// </summary>
	public void UpdateSpritesForTest(){
		for (int i = 0; i < Buffer.getLength(); i++)
				{
					Buffer.SetCoordinates(i, new Vector2((float)Rnd.NextDouble()*1000,(float)Rnd.NextDouble()*1000));
					//Buffer.SetTexture(i, Builder.GetTexture());
				}
	}
	 public override void _Ready()
	{
		//SetTestConstructor();
		//SetSpritesForTest();
	}

	public override void _Draw(){
	}
	public override void _Process(float delta)
	{ 
		TestPosQueueTable();
	}
}
