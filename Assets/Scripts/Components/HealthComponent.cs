using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Game, Unique]
public class HealthComponent : IComponent
{
    public int value;
}
