using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class DirectionComponent : IComponent
{
    public int value;
}
