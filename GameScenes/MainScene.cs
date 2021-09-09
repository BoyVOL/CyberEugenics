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
	TextureConstructor Builder = new TextureConstructor();
	
		ViewportTexture txt = new ViewportTexture();
	/// <summary>
	/// Задание тестового экземпляра конструктора текстур и его элементов
	/// </summary>
	public void SetTestConstructor(){

	}
	/// <summary>
	/// Метод для задания начальной точки тестового буффера
	/// </summary>
	public void SetSpritesForTest(){
		TestTexture = ResourceLoader.Load<Texture>("res://EnemyMiner.png");
		for (int i = 0; i < Buffer.getLength(); i++)
		{
			Buffer.SetSize(i,new Vector2(1,1));
			Buffer.SetTexture(i, TestTexture);
			Buffer.SetCoordinates(i, new Vector2((float)Rnd.NextDouble()*1000,(float)Rnd.NextDouble()*1000));
			Buffer.SetVisible(i,true);
			Buffer.AddAsChild(i,this);
		}
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
	/// Функция обновления тестового массива спрайтов
	/// </summary>
	public void UpdateSpritesForTest(){
		for (int i = 0; i < Buffer.getLength(); i++)
				{
					Buffer.SetCoordinates(i, new Vector2((float)Rnd.NextDouble()*1000,(float)Rnd.NextDouble()*1000));
				}
	}
	 public override void _Ready()
	{
		SetTestConstructor();
		//SetSpritesForTest();
	}

	public override void _Draw(){
	}
	public override void _Process(float delta)
	{ 
		TestImageGeneration();
		//UpdateSpritesForTest();
	}
}
