using Godot;
using System;


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
	SpriteBufferArray Buffer = new SpriteBufferArray(10000);
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
			Buffer.SetVisible(i,false);
			Buffer.AddAsChild(i,this);
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
		SetSpritesForTest();
	}
	public override void _Process(float delta)
	{ 
		UpdateSpritesForTest();
	}
}
