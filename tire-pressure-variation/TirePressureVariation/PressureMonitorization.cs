namespace KataTirePressureVariation;

public class PressureMonitorization
{
	readonly INotifier notifier;

	public PressureMonitorization(SafetyRange safetyRange, INotifier notifier, IPressureSensor pressureSensor)
	{
		this.notifier = notifier;
	}

	public void Check()
	{
		notifier.Send("Alarm activated");
	}
}