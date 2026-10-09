namespace HarvestValley.Scenes;

internal sealed partial class SceneManager
{
    private void ChangeTo(SceneKind destination)
    {
        if (destination == Current.Kind)
        {
            return;
        }

        _destination = destination;
        _fadingOut = true;
        _elapsed = 0;
    }
}
