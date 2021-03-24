# CppWrapperExample

This is an example of how to build a C++ library, called by a .net wrapper, for use in a Hypar function. There are several components:
- `/cpp` - Contains the C++ source code and cmake file.
- `/src` - Contains the .net source code.
- `/test` - Contains the .net test source code.
- `Dockerfile` - The Docker file describes the setup of your docker container with all pre-requisites to build C++ code for linux and run .net tests.

# Why do I need a container?
Your C++ must be compiled for Linux in order to run on Hypar. Hypar functions run on Amazon Lambda, which runs on Linux. Using a docker container based on the Amazon Linux 2 image, the same used by Amazon to run Lambda, you can use the container to compile, test, and even publish your code.

## Building the Container
The following command will build the docker image and tag it with the name `hypar-cpp` so that it's easy to reference later.
```
docker build . -t hypar-cpp
```

## Running the Container
The following command will run the docker container interactively and bind the function directory to the `/function` directory in the container. If successful, you'll be presented with a command prompt running inside the container from which you can run commands.
```
docker run -it --mount src="$(pwd)",target=/function,type=bind hypar-cpp
```

## Building the C++ Code in the Container
From the container's command line:
```
cd cpp/build
cmake3 ..
make
```
If the build is successful, the `.so` file will be written to the `/build` directory. The .net wrapper's `.csproj` has a copy step which will copy this `.so` to the build directory so that it is packaged with your function.

|Input Name|Type|Description|
|---|---|---|
|Length|number|The Length.|
|Width|number|The Width.|


<br>

|Output Name|Type|Description|
|---|---|---|
|Volume|Number|The volume.|

