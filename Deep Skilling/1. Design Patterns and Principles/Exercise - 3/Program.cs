using BuilderPatternExample;

Computer computer = new Computer.Builder()
                        .SetCPU("Intel i7")
                        .SetRAM("16 GB")
                        .SetStorage("512 GB SSD")
                        .Build();

computer.Display();