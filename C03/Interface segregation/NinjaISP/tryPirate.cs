using System.Numerics;

namespace NinjaISP;

public class PirateTry : IAttackable, IAttacker
{
    private readonly List<Weapon> _weapons;

    public PirateTry(string name, params Weapon[] weapons)
    {
        _weapons = new(weapons);
        Name = name;
    }

    public string Name { get; }

    public Vector2 Position { get; set; }

    public AttackResult Attack(IAttackable target)
    {
        var distance = this.DistanceFrom(target);
        foreach (var weapon in _weapons)
        {
            if (weapon.CanHit(distance))
            {
                return new AttackResult(weapon, this, target);
            }
        }
        return new(new NoWeapon(), this, target);
    }

    private class NoWeapon: Weapon
    {
        public override float MinRanged => 0;

        public override float MaxRanged => 0;

        public override string Name { get; } = "Nothing";

        public override bool CanHit(float distance) => false;
    }
}

public class KickTry: Weapon
{
    public override float MinRanged { get; } = 0;
    public override float MaxRanged { get; } = 0;
}

public class CutlassTry : Sword { }

public class BoardingAxeTry: Weapon
{
    public override float MinRanged { get; } = 0;
    public override float MaxRanged { get; } = 5;
}

public class BlunderbussTry: Weapon
{
    public override float MinRanged { get; } = 3;
    public override float MaxRanged { get; } = 100;
}