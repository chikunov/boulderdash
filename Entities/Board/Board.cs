using System.Collections.Generic;
using BoulderDash.Entities.Tiles;
using BoulderDash.Utils;
using Godot;
using JetBrains.Annotations;

namespace BoulderDash.Entities
{
    public class Board : Node2D
    {
        [Export] private NodePath _gridPath;
        [Export] private NodePath _tileFactoryPath;

        private Grid _grid;
        private TileFactory _tileFactory;
        private Dictionary<Vector2Int, Tile> _tiles;

        public override void _Ready()
        {
            _grid = GetNode<Grid>(_gridPath);
            _tileFactory = GetNode<TileFactory>(_tileFactoryPath);
            _tiles = new Dictionary<Vector2Int, Tile>();

            GenerateBoard();
        }

        [CanBeNull]
        public T GetTile<T>(Vector2Int boardPosition) where T : Tile
        {
            if (_tiles.TryGetValue(boardPosition, out var tile))
            {
                return tile as T;
            }

            return null;
        }

        public void AddWallTile(Vector2Int boardPosition)
        {
            var wallTile = _tileFactory.CreateWallTile(this, boardPosition);
            _tiles.Add(boardPosition, wallTile);
        }

        public void AddDirtTile(Vector2Int boardPosition)
        {
            var dirtTile = _tileFactory.CreateDirtTile(this, boardPosition);
            _tiles.Add(boardPosition, dirtTile);
        }

        public void RemoveTile(Vector2Int boardPosition)
        {
            _tiles.Remove(boardPosition);
        }

        public Vector2 GetTileLocalPosition(Vector2Int tilePosition)
        {
            return _grid.GetCellLocalPosition(tilePosition);
        }

        private void GenerateBoard()
        {
            for (var x = 0; x < 10; x++)
            {
                for (var y = 0; y < 10; y++)
                {
                    if (x == 0 || y == 0 || x == 9 || y == 9)
                    {
                        AddWallTile(new Vector2Int(x, y));
                    }
                    else
                    {
                        AddDirtTile(new Vector2Int(x, y));
                    }
                }
            }
        }
    }
}