namespace FightForHonorGame.Personages.Body;

public sealed record Leg(ICharacter Owner) : BodyPart(Owner)
{
    protected override float DamageCoefficient => DamageCoefficients.Leg;
}