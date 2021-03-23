FROM amazonlinux:2

WORKDIR /function
COPY . .

# Install required development tools including cmake and gcc.
RUN yum -y install cmake3
RUN yum -y groupinstall "Development Tools"

# Install the dotnet sdk.
RUN rpm -Uvh https://packages.microsoft.com/config/centos/7/packages-microsoft-prod.rpm
RUN yum -y install dotnet-sdk-3.1

# Set an environment variable to ignore telemetry
ENV DOTNET_CLI_TELEMETRY_OPTOUT=1
ENV DOTNET_NOLOGO=1

# Build the cpp library.
RUN cd cpp/build && cmake3 .. && make

# Run the wrapper tests.
ENTRYPOINT [ "dotnet", "test" ]