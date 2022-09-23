using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Game, Unique]
public class InitialPositionComponent : IComponent
{
    public Vector3 value;
}
