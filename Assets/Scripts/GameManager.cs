using UnityEngine;
using Enums;

public class GameManager : MonoBehaviour
{
    //

    public Match Match;
    public TurnManager TurnManager;
    public CombatResolver CombatResolver;
    public GameBoard Board;

    public Player player;
    public Player reflection;

    public GameManager(Match match, TurnManager turnManager, CombatResolver combatResolver, GameBoard board)
    {
        Match = match;
        TurnManager = turnManager;
        CombatResolver = combatResolver;
        Board = board;
    }

    public void PlayerMaker(DeckInstance HumanDeck, DeckInstance ReflectionDeck)
    {
        player = new Player(CardTeam.Human, HumanDeck);
        reflection = new Player(CardTeam.Reflection, ReflectionDeck);
    }

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
        GameManager instance = new GameManager(new Match(), new TurnManager(), new CombatResolver(), new GameBoard());
    }

    void Update()
    {
        
    }
}
