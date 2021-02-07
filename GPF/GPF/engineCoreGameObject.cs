using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

public struct Vector2
{
  public float x;
  public float y;
}

public class transform
{
  public Vector2 position;
  public readonly float scale = 1.0f;
  public readonly float rotation = 0f;
}

public class Component
{
  public virtual void Draw(Vector2 position) { }
  public virtual void Update() { }
}

public class gameObject
{
  public transform worldTransform = new transform();
  public ScriptComponent attachedScript;
  public TextComponent attachedText;
  public SpriteComponent attachedSprite;
  public string name;
  public List<Component> AttachedComponents = new List<Component>();

  static gameObject Find(string nameToFind)
  {
    foreach(gameObject nextObject in Scene.SceneObjects)
    {
      if(nextObject.name == nameToFind)
      {
        return nextObject;
      }
    }
    return null;
  }

  public static gameObject Instantiate()
  {
    return Instantiate("newObject");
  }

  public static gameObject Instantiate(string objectName)
  {
    gameObject spawningObject = new gameObject();
    spawningObject.name = objectName;
    Scene.SceneObjects.Add(spawningObject);
    return(spawningObject);
  }

  public void CollisionCheck()
  {
    foreach(gameObject nextObject in Scene.SceneObjects)
    {
      if(nextObject == this) continue;
      Vector2 other = nextObject.worldTransform.position;
      Vector2 current = worldTransform.position;
      if((int)other.x == (int)current.x && (int)other.y == (int)current.y)
      {
        if(nextObject.attachedScript!=null)
        {
          nextObject.attachedScript.OnCollision(this);
        }
        if(attachedScript!=null)
        {
          attachedScript.OnCollision(nextObject);
        }
      }
    }
  }

  public void Update()
  {
    foreach(Component c in AttachedComponents)
      c.Update();
  }

  public void Draw()
  {
    if(worldTransform.position.x < 0 || worldTransform.position.x > Scene.width-1)
      return;
    if(worldTransform.position.y < 0 || worldTransform.position.y > Scene.height-1)
      return;
    foreach(Component c in AttachedComponents)
    {
      Vector2 screenpos = worldTransform.position;
      screenpos.x++;
      screenpos.y++;
      c.Draw(screenpos);
    }
  }

  public T GetComponent<T>() where T: Component
  {
    foreach(Component c in AttachedComponents)
      if(c as T != null) return (T)c;
    return null;
  }

  public void attachScript(ScriptComponent scriptToAttach)
  {
    attachedScript = scriptToAttach;
    scriptToAttach.objectAttachedTo = this;
    scriptToAttach.worldTransform = worldTransform;
    AttachedComponents.Add(scriptToAttach);
    scriptToAttach.objectAttachedTo = this;
    scriptToAttach.worldTransform = worldTransform;
  }

  public TextComponent attachTextComponent()
  {
    TextComponent textToAttach = new TextComponent();
    AttachedComponents.Add(textToAttach);
    return textToAttach;
  }

  public SpriteComponent attachSprite(char newSpriteImage)
  {
    SpriteComponent spriteToAttach = new SpriteComponent();
    spriteToAttach.spriteImage = newSpriteImage;
    AttachedComponents.Add(spriteToAttach);
    return spriteToAttach;
  }
}