namespace FightForHonorGame.Personages;

public interface IDamageable
{
    float CalculateDamage(float baseDamage);

    void SetDefence(bool isUnderDefence);
}