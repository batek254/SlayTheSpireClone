using Godot;
using System;

[GlobalClass]
public partial class Card : Resource
{
    public enum Type
    {
        Attack,
        Defend,
        Power
    }
    public enum Target
    {
        Self,
        Single_enemy,
        All_enemies,
        Everyone
    }
    [ExportGroup("Card Attributes")]
    [Export]
    public string id { get; set; }
    [Export]
    public Type type { get; set; }
    [Export]
    public Target target { get; set; }

    public Card()
    {
        id = "default";
        type = Type.Attack;
        target = Target.Single_enemy;
    }

    public bool IsSingleTargeted()
    {
        return target == Target.Single_enemy;
    }
}
