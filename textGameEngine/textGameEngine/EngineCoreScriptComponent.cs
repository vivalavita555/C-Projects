using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace textGameEngine
{
    public class EngineCoreScriptComponent
    {
        public class ScriptComponent : Component
        {
            public gameObject objectAttachedTo;
            public transform worldTransform;

            public virtual void OnCollision(gameObject ObjectCollidedWith) { }

            public override void Update() { }

            public virtual void Start() { }
        }

    }
}



