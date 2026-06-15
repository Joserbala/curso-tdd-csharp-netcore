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
            var pressureSensor = GetPressureSensorWith(16);
            var pressureMonitorization = new PressureMonitorization(safetyRange, notifier, pressureSensor);

            pressureMonitorization.Check();
            
            notifier.Received().Send("Alarm activated");
        }

        [Test]
        public void Alarm_Deactivated_With_Safe_Pressure_Remains_Deactivated()
        {
            var safetyRange = new SafetyRange(17, 21);
            var notifier = Substitute.For<INotifier>(); // spy
            var pressureSensor = GetPressureSensorWith(17);
            var pressureMonitorization = new PressureMonitorization(safetyRange, notifier, pressureSensor);

            pressureMonitorization.Check();

            notifier.DidNotReceiveWithAnyArgs().Send(Arg.Any<string>());
        }

        static IPressureSensor GetPressureSensorWith(int pressure)
        {
            var pressureSensor = Substitute.For<IPressureSensor>(); // stub
            pressureSensor.Get().Returns(pressure);
            return pressureSensor;
        }
    }
}