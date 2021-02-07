class sampleGame
{
  public static void Start()
  {
    Scene level1 = new Scene();

    gameObject scoreTextBox = gameObject.Instantiate();
    scoreTextBox.worldTransform.position.x = 1;
    scoreTextBox.worldTransform.position.y = 1;
    TextComponent scoreText = scoreTextBox.attachTextComponent();

    gameObject player = gameObject.Instantiate();
    playerScript playerControllerScript = new playerScript();
    playerControllerScript.scoreOutputText = scoreText;
    player.attachScript(playerControllerScript);

    gameObject pickup = gameObject.Instantiate();
    pickup.attachScript(new pickupScript());
    level1.Run();
  }
}