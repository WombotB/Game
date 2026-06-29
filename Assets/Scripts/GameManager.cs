using UnityEngine;
using Enums;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public Match Match;
    public TurnManager TurnManager;
    public CombatResolver CombatResolver;
    public GameBoard Board;

    public GameManager(Match match, TurnManager turnManager, CombatResolver combatResolver, GameBoard board)
    {
        Match = match;
        TurnManager = turnManager;
        CombatResolver = combatResolver;
        Board = board;
    }

    public void PlayerMaker(DeckInstance HumanDeck, DeckInstance ReflectionDeck)
    {
        Match.Player = new Player(CardTeam.Human, HumanDeck);
        Match.Reflection = new Player(CardTeam.Reflection, ReflectionDeck);
    }

    public void CheckWin()
    {
        //Проверяет победу
    }

    public void EndTurn()
    {
        //Заканчивает ход
    }

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        Match = new Match();

        Match.Board = new GameBoard();

        Match.Player = new Player(CardTeam.Human, new DeckInstance(humanDeck));

        Match.Reflection = new Player(CardTeam.Reflection, new DeckInstance(reflectionDeck));

        TurnManager = new TurnManager();
        CombatResolver = new CombatResolver();
    }

    void Update()
    {
        
    }
}
