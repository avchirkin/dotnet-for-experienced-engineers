namespace FightForHonorGame.Personages.Body;

public sealed record Hand(ICharacter Owner) : BodyPart(Owner)
{
    protected override float DamageCoefficient => DamageCoefficients.Hand;
}