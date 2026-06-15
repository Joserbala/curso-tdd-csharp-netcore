using KataTirePressureVariation;
using NSubstitute;
using NUnit.Framework;

namespace TirePressureVariation.Test
{
    public class AlarmShould
    {
        INotifier notifier;
        IPressureSensor pressureSensor;
        PressureMonitorization pressureMonitorization;

        [SetUp]
        public void SetUp()
        {
            var safetyRange = new SafetyRange(17, 21);
            notifier = Substitute.For<INotifier>();
            pressureSensor = Substitute.For<IPressureSensor>();
            pressureMonitorization = new PressureMonitorization(safetyRange, notifier, pressureSensor);
        }

        [TestCase(16)]
        [TestCase(22)]
        public void Alarm_Deactivated_With_Dangerous_Pressure_Activates_The_Alarm(int pressure)
        {
            pressureSensor.Get().Returns(pressure);
            
            pressureMonitorization.Check();

            notifier.Received().Send("Alarm activated");
        }

        [TestCase(17)]
        [TestCase(21)]
        public void Alarm_Deactivated_With_Safe_Pressure_Remains_Deactivated(int pressure)
        {
            pressureSensor.Get().Returns(pressure);

            pressureMonitorization.Check();

            notifier.DidNotReceive().Send(Arg.Any<string>());
        }
    }
}