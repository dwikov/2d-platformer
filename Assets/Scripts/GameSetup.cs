using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[CreateAssetMenu]
[Game, Unique]
public class GameSetup : ScriptableObject
{
    public GameObject character;
    public GameObject fire;
    public GameObject pig;
}
