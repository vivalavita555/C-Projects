using System;

public class SpriteComponent : Component
{
  public char spriteImage='\0';

  public override void Draw(Vector2 location)
  {
    Console.SetCursorPosition((int)location.x, (int)location.y);
    Console.Write(spriteImage);
  }
}