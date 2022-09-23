using Entitas;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameSetup gameSetup;
    private Systems _systems;
    // Start is called before the first frame update
    void Start()
    {
        var contexts = Contexts.sharedInstance;

        contexts.game.SetGameSetup(gameSetup);
        _systems = CreateSystems(contexts);
        _systems.Initialize();
        
    }

    // Update is called once per frame
    void Update()
    {
        _systems.Execute();
    }

    private Systems CreateSystems(Contexts contexts)
    {
        return new Feature("Game")
            .Add(new InitializePlayerSystem(contexts))
            .Add(new InstantiateViewSystem(contexts))
            .Add(new InputSystem(contexts))
            .Add(new PlayerMovementSystem(contexts))
            .Add(new PlayerDirectionSystem(contexts))
            .Add(new PlayerAnimationSystem(contexts))
            .Add(new PlayerJumpSystem(contexts))
            .Add(new InitializeFireSystem(contexts))
            .Add(new InitializePigSystem(contexts))
            .Add(new CollisionSystem(contexts))
            .Add(new PigAnimationSystem(contexts))
          
            .Add(new PigMovementSystem(contexts))
            .Add(new PigDirectionSystem(contexts));
    }
}
