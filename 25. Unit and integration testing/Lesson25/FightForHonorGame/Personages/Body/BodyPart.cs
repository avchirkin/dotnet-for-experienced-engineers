namespace FightForHonorGame.Personages.Body;

public abstract record BodyPart(ICharacter Owner) : IDamageable
{
    protected abstract float DamageCoefficient { get; }

    public bool IsUnderDefence { get; private set; }

    public virtual float CalculateDamage(float damage)
    {
        return IsUnderDefence ?
            damage * DamageCoefficient / 2
            : damage * DamageCoefficient;
    }

    public void SetDefence(bool isUnderDefence)
    {
        IsUnderDefence = isUnderDefence;
    }
}