using System;

namespace HarvestValley.Scenes;

internal sealed partial class SceneManager
{
    public float FadeOpacity => !IsTransitioning ? 0 : (float)Math.Clamp(_fadingOut ? _elapsed / FadeDuration : 1 - _elapsed / FadeDuration, 0, 1);
}
