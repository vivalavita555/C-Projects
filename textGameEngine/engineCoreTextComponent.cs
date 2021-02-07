using System;

public class TextComponent : Component
{
  public string text;

  public override void Draw(Vector2 position)
  {
    Console.SetCursorPosition((int)position.x, (int)position.y);
    Console.Write(text);
  }
}