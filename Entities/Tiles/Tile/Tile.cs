using BoulderDash.Utils;
using Godot;
using JetBrains.Annotations;

namespace BoulderDash.Entities.Tiles
{
    public abstract class Tile : Node2D
    {
        [CanBeNull] public Board OwningBoard { get; private set; }

        public void Initialize([NotNull] Board owningBoard, Vector2Int position)
        {
            OwningBoard = owningBoard;
            Name = $"Tile {position.ToString()}";
            SetBoardPosition(position);
        }

        public void SetBoardPosition(Vector2Int position)
        {
            if (OwningBoard == null) return;

            Position = OwningBoard.GetTileLocalPosition(position);
        }
    }
}