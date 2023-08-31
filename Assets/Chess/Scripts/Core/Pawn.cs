using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : ChessPiece {
    public Pawn(Vector2Int position, Color color) : base(position, color) { }

    public override List<Vector2Int> CalculatePossibleMoves() {
        List<Vector2Int> moves = new List<Vector2Int>();
        // Calculate possible moves for the king

        ForwardMove(moves);
        CaptureMoves(moves);
        //InitialDoubleMove(moves);

        return moves;
    }
    void ForwardMove(List<Vector2Int> moves) {
        int forwardDirection = (Color == Color.black) ? 1 : -1;
        Vector2Int forwardOne = Position + new Vector2Int(0, forwardDirection);

        if (IsMoveValid(forwardOne)) {
            moves.Add(forwardOne);

            // Check for initial double move
            Vector2Int forwardTwo = Position + new Vector2Int(0, forwardDirection * 2);
            if (IsMoveValid(forwardTwo) && IsMoveValid(forwardOne) && (forwardDirection == 1 && Position.y == 1) || (forwardDirection == -1 && Position.y == 6)) {
                moves.Add(forwardTwo);
            }
        }
    }

    void CaptureMoves(List<Vector2Int> moves) {
        int forwardDirection = (Color == Color.black) ? 1 : -1;

        Vector2Int captureLeft = Position + new Vector2Int(-1, forwardDirection);
        Vector2Int captureRight = Position + new Vector2Int(1, forwardDirection);

        if (IsMoveValid(captureLeft)) {
            moves.Add(captureLeft);
        }

        if (IsMoveValid(captureRight)) {
            moves.Add(captureRight);
        }
    }

}
