using CommandPatternExample;

Light light = new Light();

RemoteControl remote = new RemoteControl();

remote.SetCommand(new LightOnCommand(light));
remote.PressButton();

remote.SetCommand(new LightOffCommand(light));
remote.PressButton();