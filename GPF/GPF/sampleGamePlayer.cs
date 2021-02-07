using System;

class playerScript : ScriptComponent
{
  public TextComponent scoreOutputText;
  int score = 0;

    //This function checks the timer and removes a life if you spent too long
    //without collecting any pickups
    int pickupTimer = 0;
    int lives = 3;
    public void CheckPickupTimer()
    {
        //Update how llong it's been since the last pickup was collected
        pickupTimer += 50; //We run at 20fps, so a frame should be 50ms
        //IF it's been more than 15 seconds
        if(pickupTimer > 15000)
        {
            //THEN Reset the pickup timer
            pickupTimer = 0;
            //Remove a life from the player
            lives--;
            //IF the player has ran out of lives
            if (lives <= 0)
            {
                //THEN stop the game
                Scene.exiting = true;
                //The exiting boolean is built into the Scene class and will close the game
            }
        }
    }

    public int CheckKeys()
    {
        if (Input.GetKey('a') && worldTransform.position.x > 0)
        {
            worldTransform.position.x--;
            return -1; //moving left
        }

        if (Input.GetKey('d') && worldTransform.position.x < 39)
        {
            worldTransform.position.x++;
            return +1; //moving right
        }
        return 0; //not moving
    }

    public void ChangeSprite(char newSprite)
    {
        objectAttachedTo.GetComponent<SpriteComponent>().spriteImage = newSprite;
    }
  /*
   * Start function: runs on player spawn only.
   * Parameters: none
   * Returns: nothing (void)
   */
  public override void Start()
  {
      int score = 0;

      objectAttachedTo.attachSprite('@');
      worldTransform.position.x = 20;
      worldTransform.position.y = 28;
  }

  public override void OnCollision(gameObject ObjectCollidedWith)
  {
        for (int loops = 1; loops < 5; loops++)
        {
            System.Console.Beep(loops * 1000, 250);
        }
        score++;
        pickupScript gotPickup = ObjectCollidedWith.GetComponent<pickupScript>();
        if(!(gotPickup == null)) //Check the script exists before using it
        {
            gotPickup.Spawn(); //Then collect the pickup, make it respawn
        }
        gotPickup.fallSpeed += 0.05f;
        pickupTimer = 0;
  }

  public override void Update()
  {
        scoreOutputText.text = "Points: " + score + ", lives: ";
        int LivesCounter = 0;                   //set up variable to use in loop condition
        do
        {
            scoreOutputText.text = scoreOutputText.text + "*"; //add one dot each repitition
            LivesCounter++;                     //count how many repititions we've done so far
        } while (LivesCounter < lives);         //if not reached 3 repititions yet, go back to the 'do'

        scoreOutputText.text += "\n ";
        int fuelCounter = 15000 - pickupTimer;  //set up a variable to use in loop condition
        while(fuelCounter > 500)
        {
            scoreOutputText.text += "-";        //add one dash each repitition
            fuelCounter -= 1000;
        }

        switch (CheckKeys())
        {
            case -1:
                ChangeSprite('<');
                break;
            case 0:
                ChangeSprite('@');
                break;
            case +1:
                ChangeSprite('>');
                break;
        }

        //switch (score)
        //{
        //    case 0:
        //        scoreOutputText.text = "Catch the falling star!";
        //        break;
        //    case 1:
        //        scoreOutputText.text = "Got one. Catch another!";
        //        break;
        //    case 2:
        //        scoreOutputText.text = "Two's company. Keep it up!";
        //        break;
        //    default:
        //        scoreOutputText.text = "You now have " + score + " stars.";
        //        break;
        //}

        CheckPickupTimer();

        if (lives <= 0)
        {
            Console.Clear();
            for(int x = 5; x <15; x++)
            {
                for(int y = 3; y < 13; y++)
                {
                    Console.SetCursorPosition(x * 2, y * 2);
                    Console.Write('#');
                }
            }
            Console.SetCursorPosition(15, 15);
            Console.WriteLine("YOU DIED");
            do { }
            while (!Console.KeyAvailable);
            Scene.exiting = true;
        }
  }
}
