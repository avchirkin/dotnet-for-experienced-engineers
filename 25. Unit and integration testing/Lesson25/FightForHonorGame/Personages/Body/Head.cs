namespace FightForHonorGame.Personages.Body;

public sealed record Head(ICharacter Owner) : BodyPart(Owner)
{
    protected override float DamageCoefficient => DamageCoefficients.Head;
}