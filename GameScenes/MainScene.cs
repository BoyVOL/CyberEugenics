using Godot;
using System;

public class MainScene : Node2D
{
    /// <summary>
    /// Поле для теста многопоточности.
    /// </summary>
    /// <returns></returns>
    TestClass Test = new TestClass();
    Texture Textr = GD.Load<Texture>("res://EnemyMiner.png");
    Texture Textr2 = GD.Load<Texture>("res://icon.png");

    Random Rnd = new Random();
    Sprite[,] SpriteArray = new Sprite[1000000,2];
    Path[] Paths = new Path[1000000];
    Line2D[] LineArray = new Line2D[1000000];

    Navigation2D Nav = new Navigation2D();

    int CurrentIndex = 0;
    float Pass = 0;
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

   



void SpriteInit(int Spriteumber){
    for (int i = 0; i < Spriteumber; i++)
        {
            Sprite Temp = new Sprite();
            Sprite Temp2 = new Sprite();
            Temp.Texture = Textr;
            Temp2.Texture = Textr;
            //Temp.Visible = false;
            //Temp2.Visible = false;
            this.AddChild(Temp);
            SpriteArray[i,0] = Temp;
            SpriteArray[i,1] = Temp2;
            Temp.AddChild(Temp2);
            Temp2.Translate(new Vector2(10,10));
        }
}

void LineInit(int Spriteumber){
    for (int i = 0; i < Spriteumber; i++)
        {
            Line2D Temp = new Line2D();
            //Temp.Texture = Textr;
            //Temp.Visible = false;
            this.AddChild(Temp);
            LineArray[i] = Temp;
            Temp.AddPoint(new Vector2(10,10));
            Temp.AddPoint(new Vector2(20,20));
        }
}


void SpriteUpdate(){
    for (int i = 0; i < 10000; i++)
        {
            SpriteArray[i,0].Translate(new Vector2((float)Rnd.NextDouble()*10,(float)Rnd.NextDouble()*10));
            SpriteArray[i,1].Rotate((float)Rnd.NextDouble());
        }
}

 void ConsoleLog(){
     GD.Print("LOL");
     System.Threading.Thread.Sleep(100);
}

void LineUpdate(int Spriteumber){
    for (int i = 0; i < Spriteumber; i++)
        {        
            LineArray[i].Translate(new Vector2((float)Rnd.NextDouble()*10,(float)Rnd.NextDouble()*10));
            LineArray[i].Rotate((float)Rnd.NextDouble());
            //LineArray[i].AddPoint(new Vector2((float)Rnd.NextDouble()*10,(float)Rnd.NextDouble()*10));
        }
}
 
 //  // Called every frame. 'delta' is the elapsed time since the previous frame.

 void DrawCircle(){  
    for (int i = 0; i < 2000; i++)
    {
        DrawCircle(new Vector2((float)Rnd.NextDouble()*1000,(float)Rnd.NextDouble()*1000),10,Colors.Red);
    }
 }

 void DrawTexture(){
    for (int i = 0; i < 20000; i++)
    {
        DrawTexture(Textr,new Vector2((float)Rnd.NextDouble()*1000,(float)Rnd.NextDouble()*1000));
    }
 }  
public override void _Draw()
{
        //DrawTexture();
}

 // Called when the node enters the scene tree for the first time.
     public override void _Ready()
    {
        Test = new TestClass();
    }
    public override void _Process(float delta)
    {
        Unit testUnit = new Unit();
        System.Threading.Thread Thread = new System.Threading.Thread(Test.ChangeData1);
        System.Threading.Thread Thread2 = new System.Threading.Thread(Test.ChangeData2);
        System.Threading.Thread Thread3 = new System.Threading.Thread(Test.ChangeData3);
        Thread.Start();
        Thread2.Start();
        Thread3.Start();
        Thread.Join();
        Thread2.Join();
        Thread3.Join();       
    }
}
