namespace CommandPatternExample
{
    public class RemoteControl
    {
        private Command? command;

        public void SetCommand(Command command)
        {
            this.command = command;
        }

        public void PressButton()
        {
            command?.Execute();
        }
    }
}