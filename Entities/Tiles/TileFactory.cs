using BoulderDash.Utils;
using Godot;
using JetBrains.Annotations;

namespace BoulderDash.Entities.Tiles
{
    public class TileFactory : Node
    {
        [Export] private PackedScene _wallTileScene;
        [Export] private PackedScene _dirtTileScene;

        [NotNull]
        public WallTile CreateWallTile([NotNull] Board board, Vector2Int boardPosition)
        {
            var wallTile = _wallTileScene.Instance<WallTile>();
            wallTile.Initialize(board, boardPosition);
            board.AddChild(wallTile);
            return wallTile;
        }

        [NotNull]
        public DirtTile CreateDirtTile([NotNull] Board board, Vector2Int boardPosition)
        {
            var dirtTile = _dirtTileScene.Instance<DirtTile>();
            dirtTile.Initialize(board, boardPosition);
            board.AddChild(dirtTile);
            return dirtTile;
        }
    }
}