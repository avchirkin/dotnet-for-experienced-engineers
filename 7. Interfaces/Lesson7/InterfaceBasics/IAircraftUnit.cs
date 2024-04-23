namespace InterfaceBasics;

public interface IAircraftUnit
{
    float MaxFlightHeight { get; }
    float MaxFlightSpeed { get; }
    void ChangeFlightCourse(float newDirection, float newHeight, float newSpeed);
}