using KataTirePressureVariation;
using NSubstitute;
using NUnit.Framework;

namespace TirePressureVariation.Test
{
    public class AlarmShould
    {
        const int MinimumSafetyValue = 17;
        const int MaximumSafetyValue = 21;
        const int MinimumUnsafetyValue = 16;
        const int MaximumUnsafetyValue = 22;

        INotifier notifier;
        IPressureSensor pressureSensor;
        PressureMonitorization pressureMonitorization;

        [SetUp]
        public void SetUp()
        {
            var safetyRange = new SafetyRange(MinimumSafetyValue, MaximumSafetyValue);
            notifier = Substitute.For<INotifier>();
            pressureSensor = Substitute.For<IPressureSensor>();
            pressureMonitorization = new PressureMonitorization(safetyRange, notifier, pressureSensor);
        }

        [TestCase(MinimumUnsafetyValue)]
        [TestCase(MaximumUnsafetyValue)]
        public void Alarm_Deactivated_With_Dangerous_Pressure_Activates_The_Alarm(int pressure)
        {
            pressureSensor.Get().Returns(pressure);
            
            pressureMonitorization.Check();

            notifier.Received().Send("Alarm activated");
        }

        [TestCase(MinimumSafetyValue)]
        [TestCase(MaximumSafetyValue)]
        public void Alarm_Deactivated_With_Safe_Pressure_Remains_Deactivated(int pressure)
        {
            pressureSensor.Get().Returns(pressure);

            pressureMonitorization.Check();

            notifier.DidNotReceive().Send(Arg.Any<string>());
        }

        [Test]
        public void Alarm_Activated_With_Dangerous_Pressure_Remains_Activated()
        {
            pressureSensor.Get().Returns(MinimumUnsafetyValue);
            pressureMonitorization.Check();
            pressureSensor.Get().Returns(MinimumUnsafetyValue);

            pressureMonitorization.Check();

            notifier.Received(1).Send("Alarm activated");
        }
    }
}