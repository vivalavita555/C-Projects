class playerScript : ScriptComponent
{
  public TextComponent scoreOutputText;
  int score = 0;

  public override void Start()
  {
    objectAttachedTo.attachSprite('@');
    worldTransform.position.x=20;
    worldTransform.position.y=28;
  }

  public override void OnCollision(gameObject ObjectCollidedWith)
  {
  }

  public override void Update()
  {
    scoreOutputText.text = "Points: " + score;
    score += 10;
    worldTransform.position.x ++;
    worldTransform.position.y --;
  }
}
