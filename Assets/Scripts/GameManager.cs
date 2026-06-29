using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Match Match;
    public TurnManager TurnManager;
    public CombatResolver CombatResolver;
    public GameBoard GameBoard;

    public Player Player;
    public Player Reflection;

    /*public GameManager()
    {
        Turn = 0;
        IsEnded = false;
        IsWin = false;
    }*/

    public void CheckWin()
    {
        //Проверяет победу
    }

    public void EndTurn()
    {
        //Заканчивает ход
    }

    void Start()
    {
        var game = new GameManager();
    }

    void Update()
    {
        
    }
}
