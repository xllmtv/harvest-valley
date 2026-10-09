using HarvestValley.Input;
using Microsoft.Xna.Framework.Graphics;

namespace HarvestValley.Scenes;

internal sealed partial class SceneManager
{
    public bool Update(double deltaSeconds, InputFrame input, Viewport viewport)
    {
        if (IsTransitioning)
        {
            _elapsed += deltaSeconds;
            if (_fadingOut && _elapsed >= FadeDuration)
            {
                GameScene next = _createScene(_destination!.Value);
                Current.Dispose();
                Current = next;
                _elapsed -= FadeDuration;
                _fadingOut = false;
                SceneChanged?.Invoke(Current.Kind);
            }

            if (!_fadingOut && _elapsed >= FadeDuration)
            {
                _destination = null;
            }

            return false;
        }

        switch (Current.Update(deltaSeconds, input, viewport))
        {
            case SceneAction.Play:
                ChangeTo(SceneKind.Gameplay);
                break;
            case SceneAction.MainMenu:
                ChangeTo(SceneKind.MainMenu);
                break;
            case SceneAction.Exit:
                return true;
        }

        return false;
    }
}
