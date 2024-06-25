namespace FightForHonorGame.Personages.Body;

public sealed record Torso(ICharacter Owner) : BodyPart(Owner)
{
    protected override float DamageCoefficient => DamageCoefficients.Torso;
}