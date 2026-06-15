namespace KataTirePressureVariation;

public class PressureMonitorization
{
	readonly SafetyRange safetyRange;
	readonly INotifier notifier;
	readonly IPressureSensor pressureSensor;

	public PressureMonitorization(SafetyRange safetyRange, INotifier notifier, IPressureSensor pressureSensor)
	{
		this.safetyRange = safetyRange;
		this.notifier = notifier;
		this.pressureSensor = pressureSensor;
	}

	public void Check()
	{
		var pressureValue = pressureSensor.Get();

		if (!safetyRange.IsPressureSafe(pressureValue))
		{
			notifier.Send("Alarm activated");
		}
	}
}