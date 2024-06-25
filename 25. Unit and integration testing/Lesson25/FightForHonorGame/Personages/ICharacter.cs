using FightForHonorGame.Personages.Body;

namespace FightForHonorGame.Personages;

public interface ICharacter : IHasHealth
{
    string Name { get; init; }
    bool IsAlive { get; }
    IDictionary<BodyPartType, IDamageable> Body { get; }
    void ApplyAttack(BodyPartType target, float baseDamage);
    void Defend(BodyPartType target);
}