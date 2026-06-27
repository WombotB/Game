using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int Turn;

    public GameBoard gameBoard;

    public bool IsEnded;
    public bool IsWin;

    public GameManager()
    {
        Turn = 0;
        IsEnded = false;
        IsWin = false;
    }

    public void PlayerTurn ()
    {
        //Игрок должен поставить карту
    }

    public void MirrorTurn ()
    {
        //Противник ставит карту
    }

    public void ResolveRanged()
    {
        //Ход карт дальнего боя
    }

    public void ResolveMelee()
    {
        //Ход карт ближнего боя
    }

    public void CheckWin()
    {
        //Проверяет победу
    }

    public void EndTurn()
    {
        //Заканчивает ход
        Turn += 1;
    }

    void Start()
    {
        var game = new GameManager();
    }

    void Update()
    {
        
    }
}
