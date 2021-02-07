namespace textGameEngine
{
    public class SampleGamePickup
    {
        class pickupScript : ScriptComponent
        {
            public float fallSpeed = 0.2f;

            public override void Start()
            {
                objectAttachedTo.attachSprite('*');
                Spawn();
            }

            public void Spawn()
            {
                worldTransform.position.x = Randomiser.Range(0, Scene.width);
                worldTransform.position.y = 0;
            }

            public override void Update()
            {
                worldTransform.position.y += fallSpeed;
                if (worldTransform.position.y > Scene.height)
                {
                    Spawn();
                }
            }
        }
    }
}



