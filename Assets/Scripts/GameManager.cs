using UnityEngine;
using Enums;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private DeckData humanDeck;
    [SerializeField] private DeckData reflectionDeck;

    public Match Match;
    public TurnManager TurnManager;
    public CombatResolver CombatResolver;
    public GameBoard Board;

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

    }

    void Start()
    {
        Match = new Match(humanDeck, reflectionDeck);

        TurnManager = new TurnManager();

        CombatResolver = new CombatResolver();

        Instance = this;
    }

    void Update()
    {
        
    }
}
