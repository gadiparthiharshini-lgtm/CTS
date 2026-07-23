namespace CommandPatternExample
{
    public class LightOnCommand : Command
    {
        private readonly Light light;

        public LightOnCommand(Light light)
        {
            this.light = light;
        }

        public void Execute()
        {
            light.TurnOn();
        }
    }
}