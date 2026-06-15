using KataTirePressureVariation;
using NSubstitute;
using NSubstitute.ReceivedExtensions;
using NUnit.Framework;

namespace TirePressureVariation.Test
{
    public class AlarmShould
    {
        [Test]
        public void Alarm_Deactivated_With_Dangerous_Pressure_Activates_The_Alarm()
        {
            var safetyRange = new SafetyRange(17, 21);
            var notifier = Substitute.For<INotifier>(); // spy
            var pressureSensor = Substitute.For<IPressureSensor>(); // stub
            pressureSensor.Get().Returns(16);
            var pressureMonitorization = new PressureMonitorization(safetyRange, notifier, pressureSensor);

            pressureMonitorization.Check();
            
            notifier.Received().Send("Alarm activated");
        }
    }
}