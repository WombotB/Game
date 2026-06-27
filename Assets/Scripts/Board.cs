using UnityEngine;
#nullable enable


public class GameBoard : MonoBehaviour
{
    public CardInstance?[,] Board;

    public GameBoard ()
    {
        Board = new CardInstance?[5, 5];
    }

    public bool HasCard (int row, int col) => Board[row, col] != null;

    public CardInstance GetCard(int row, int col) => Board[row, col]!;

    public void SetCard (int row, int col, CardInstance card) { Board[row, col] = card; }

    public void ClearCell(int row, int col) { Board[row, col] = null; }


    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
