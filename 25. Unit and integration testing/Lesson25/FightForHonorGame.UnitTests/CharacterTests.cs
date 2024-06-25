using FightForHonorGame.Personages;
using FightForHonorGame.Personages.Body;
using NUnit.Framework;

namespace FightForHonorGame.UnitTests;

[TestFixture]
public class CharacterTests
{
    [TestCase]
    public void Character_Initializes_Correctly()
    {
        // Arrange
        var character = new Character("Black Sword", 150.0f);

        // Act
        // .. nothing here now

        // Assert
        Assert.That(character.Name, Is.EqualTo("Black Sword"));
        Assert.That(character.Health, Is.EqualTo(150));
        Assert.That(character.IsAlive, Is.True);

        Assert.That(character.Body.ContainsKey(BodyPartType.Head), Is.True);
        Assert.That(character.Body.ContainsKey(BodyPartType.LeftHand), Is.True);
        Assert.That(character.Body.ContainsKey(BodyPartType.RightHand), Is.True);
        Assert.That(character.Body.ContainsKey(BodyPartType.Torso), Is.True);
        Assert.That(character.Body.ContainsKey(BodyPartType.LeftLeg), Is.True);
        Assert.That(character.Body.ContainsKey(BodyPartType.RightLeg), Is.True);
    }

    [TestCase(BodyPartType.Head, 100, 10, DamageCoefficients.Head)]
    [TestCase(BodyPartType.LeftHand, 100, 10, DamageCoefficients.Hand)]
    [TestCase(BodyPartType.RightHand, 100, 10, DamageCoefficients.Hand)]
    [TestCase(BodyPartType.Torso, 100, 10, DamageCoefficients.Torso)]
    [TestCase(BodyPartType.LeftLeg, 100, 10, DamageCoefficients.Leg)]
    [TestCase(BodyPartType.RightLeg, 100, 10, DamageCoefficients.Leg)]
    public void Character_Applies_Attack_Correctly(BodyPartType target, float initialHealth, float baseDamage, float damageCoefficient)
    {
        // Arrange
        var character = new Character("Ivan Okunev", initialHealth);

        // Act
        character.ApplyAttack(target, baseDamage);

        // Assert
        Assert.That(character.IsAlive, Is.True);
        Assert.That(character.Health, Is.EqualTo(initialHealth - baseDamage * damageCoefficient));
    }

    [TestCase(BodyPartType.Head, 40.0f, 10.0f, true)]
    [TestCase(BodyPartType.Head, 20.0f, 10.0f, false)]
    [TestCase(BodyPartType.Head, 20.0f, 5.0f, true)]
    public void Character_IsAlive_Calculates_Correctly(BodyPartType target, float initialHealth, float baseDamage, bool expectedIsAlive)
    {
        // Arrange
        
        
        // Act
        
        
        // Assert
        
    }
}