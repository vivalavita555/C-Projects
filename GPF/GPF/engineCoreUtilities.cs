using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

static class Randomiser
{
  static Random rng = new Random();

  public static float Range(float min, float max)
  {
    float average = (min + max) / 2.0f;
    float factor = max - average;

    return (2.0f * (float)rng.NextDouble() - 1.0f) * factor + average;
  }
}

static class Input
{
  static Dictionary<char,bool> keysPressed = new Dictionary<char,bool>();

  public static void checkKeys()
  {
    keysPressed.Clear();
    while(Console.KeyAvailable)
    {
      char keyToProcess = Console.ReadKey(true).KeyChar;
      if(keysPressed.ContainsKey(keyToProcess) == false)
        keysPressed.Add(keyToProcess,true);
    }
  }

  public static bool GetKey(char whichKey)
  {
    if(keysPressed.ContainsKey(whichKey))
      return (keysPressed[whichKey]);
    else
      return false;
  }
}
