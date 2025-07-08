using System.Threading;
using GameTemplate.Constants;
using GodotUtilities;
using GTweens.Easings;
using GTweensGodot.Extensions;

namespace GameTemplate;

[Scene]
public partial class Main : Node2D
{
    [Node]
    private Sprite2D icon = null!;

    public override void _Ready()
    {
        SpinAsync().Fire();
    }

    public override void _Input(InputEvent @event)
    {
        if (@event.IsActionPressed(InputActions.LeftMouse))
        {
            GD.Print("LMB pressed");
        }
    }

    private async Task SpinAsync()
    {
        for (var i = 0; i < 100; i++)
        {
            GD.Print(icon);
            await icon.TweenScale(Vector2.One * 8, 1f)
                .SetEasing(Easing.OutQuint)
                .PlayAsync(CancellationToken.None);
            await icon.ShakeAsync(10);
            await icon.TweenScale(Vector2.One, 1f)
                .SetEasing(Easing.OutQuint)
                .PlayAsync(CancellationToken.None);
        }
    }

    public override void _Notification(int what)
    {
        if (what == NotificationSceneInstantiated)
        {
            WireNodes();
        }
    }
}