# RaspberryTests

## RaspberryGpioTest

Contains a simple program that uses the GPIO to blink a LED (if connected).

Example taken from here: https://learn.microsoft.com/en-us/dotnet/iot/tutorials/blink-led

### Building the code

The following was done on the host machine where the code was built (PC with Ubuntu 22.04):

    apt-get install mono-complete
    sudo apt-get update && sudo apt-get install -y dotnet-sdk-8.0
    sudo apt-get install -y dotnet-runtime-8.0

To add the GPIO packade, the following was done:

    dotnet add package System.Device.Gpio --version 2.2.0-*

This is how the project was built:

    dotnet build

### Running the code on the Raspberry Pi

In order to get the built code and the dependencies required to run, the
following command was run:

    dotnet publish --runtime linux-arm --self-contained

This produces a folder `bin/Release/net8.0/linux-arm/publish` that contains the
generated binaries and all the required dependencies.

To run the code on the raspberry, the code was copied to the raspberry:

    scp -r bin/Release/net8.0/linux-arm/publish pi@raspberryhostname:

Then, the raspberry was setup to run dotnet using:

    curl -sSL https://dot.net/v1/dotnet-install.sh | bash /dev/stdin --channel STS
    echo 'export DOTNET_ROOT=$HOME/.dotnet' >> ~/.bashrc
    echo 'export PATH=$PATH:$HOME/.dotnet' >> ~/.bashrc
    source ~/.bashrc

Next, the code could be run by changing to the directory where the code was
copied to:

    ~ $ cd publish
    ~/publish $ ./RaspberryGpioTest 
    Pin 17 öppnad.
    Pin 17 satt till HIGH.
    Pin 17 satt till LOW.
    Pin 17 stängd.
    Testet är klart.
    ~/publish $