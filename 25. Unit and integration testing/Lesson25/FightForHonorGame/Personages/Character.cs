using FightForHonorGame.Personages.Body;

namespace FightForHonorGame.Personages;

public sealed record Character : ICharacter
{
    private IDamageable? _underDefence;
    
    public string Name { get; init; }
    public float Health { get; set; }
    public bool IsAlive { get; set; }

    public IDictionary<BodyPartType, IDamageable> Body { get; }

    public Character(string name, float initialHealth)
    {
        Name = name;
        Health = initialHealth;
        IsAlive = true;
        Body = new Dictionary<BodyPartType, IDamageable>
        {
            { BodyPartType.Head, new Head(this) },
            { BodyPartType.LeftHand, new Hand(this) },
            { BodyPartType.RightHand, new Hand(this) },
            { BodyPartType.Torso, new Torso(this) },
            { BodyPartType.LeftLeg, new Leg(this) },
            { BodyPartType.RightLeg, new Leg(this) },
        };
    }

    public void ApplyAttack(BodyPartType target, float baseDamage)
    {
        var bodyPart = Body[target];
        var fullDamage = bodyPart.CalculateDamage(baseDamage);

        Health = Math.Max(Health - fullDamage, 0);

        if (Health == 0)
        {
            IsAlive = false;
        }
    }

    public void Defend(BodyPartType target)
    {
        var bodyPart = Body[target];
        
        _underDefence?.SetDefence(false);
        _underDefence = bodyPart;
        _underDefence.SetDefence(true);
    }
}