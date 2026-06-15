namespace KataTirePressureVariation;

public record SafetyRange
{
	readonly int minimumValue;
	readonly int maximumValue;

	public SafetyRange(int minimumValue, int maximumValue)
	{
		this.minimumValue = minimumValue;
		this.maximumValue = maximumValue;
	}

	public bool IsPressureSafe(int pressureValue)
	{
		return pressureValue <= maximumValue && pressureValue >= minimumValue;
	}
}