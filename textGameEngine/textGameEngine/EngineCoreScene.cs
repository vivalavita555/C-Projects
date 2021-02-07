using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace textGameEngine
{
    public class EngineCoreScene
    {
        class Scene
        {
            public static List<gameObject> SceneObjects = new List<gameObject>();
            public static bool exiting = false;
            public static int width = 40;
            public static int height = 30;
            private static string topline, midline, bottomline;

            static Scene()
            {
                Console.Clear();
                topline = "/";
                for (int line = 0; line < width; line++) topline = topline + '-';
                topline = topline + '\\';
                midline = "|";
                for (int line = 0; line < width; line++) midline = midline + ' ';
                midline = midline + '|';
                bottomline = "\\";
                for (int line = 0; line < width; line++) bottomline = bottomline + '-';
                bottomline = bottomline + '/';
            }

            public void Render()
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine(topline);
                for (int line = 0; line < height; line++)
                    Console.WriteLine(midline);
                Console.WriteLine(bottomline);
                foreach (gameObject nextObject in SceneObjects)
                {
                    nextObject.Draw();
                }
            }

            public void Update()
            {
                foreach (gameObject nextObject in SceneObjects)
                {
                    nextObject.Update();
                    nextObject.CollisionCheck();
                }
            }

            public void Run()
            {
                Console.CursorVisible = false;

                foreach (gameObject nextObject in SceneObjects)
                {
                    if (nextObject.attachedScript != null)
                    {
                        nextObject.attachedScript.Start();
                    }
                }

                do
                {
                    Render();
                    Update();
                    Input.checkKeys();
                    if (Input.GetKey('x'))
                        exiting = true;
                    Thread.Sleep(50);
                } while (!exiting);
                Console.SetCursorPosition(0, 32);
            }
        }
    }
}



