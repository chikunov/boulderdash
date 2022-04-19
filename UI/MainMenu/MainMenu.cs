using Godot;

namespace BoulderDash.UI
{
    public class MainMenu : Control
    {
        [Export] private NodePath _playButtonPath;
        [Export] private NodePath _editorButtonPath;
        [Export] private NodePath _quitButtonPath;

        private Button _playButton;
        private Button _editorButton;
        private Button _quitButton;

        public override void _Ready()
        {
            _playButton = GetNode<Button>(_playButtonPath);
            _editorButton = GetNode<Button>(_editorButtonPath);
            _quitButton = GetNode<Button>(_quitButtonPath);

            _quitButton.Connect("pressed", this, nameof(QuitButtonPressed));
        }

        private void QuitButtonPressed()
        {
            GetTree().Notification(MainLoop.NotificationWmQuitRequest);
        }
    }
}