using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : ChessPiece {
    public Knight(Vector2Int position, Color color) : base(position, color) { }

    public override List<Vector2Int> CalculatePossibleMoves() {
        List<Vector2Int> moves = new List<Vector2Int>();

        Vector2Int[] moveOffsets = {
            new Vector2Int(1, 2), new Vector2Int(-1, 2),
            new Vector2Int(1, -2), new Vector2Int(-1, -2),
            new Vector2Int(2, 1), new Vector2Int(-2, 1),
            new Vector2Int(2, -1), new Vector2Int(-2, -1)
        };

        foreach (Vector2Int offset in moveOffsets) {
            Vector2Int potentialMove = Position + offset;
            if (IsMoveValid(potentialMove)) {
                moves.Add(potentialMove);
            }
        }

        return moves;
    }
    // bool IsMoveValid(Vector2Int position) {
    //     // Implement logic to check if the move is within bounds and not obstructed by other pieces
    //     return true;
    // }
}
