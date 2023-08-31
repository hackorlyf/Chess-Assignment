using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessTile {
    public Vector2Int Position { get; private set; }
    public ChessPiece Piece { get; set; }

    public ChessTile(Vector2Int position) {
        Position = position;
        Piece = null;
    }
}
