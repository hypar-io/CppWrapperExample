

# CppWrapperExample

This is an example of how to build a C++ library, called by a .net wrapper, for use in a Hypar function. There are several components:
- `/cpp` - Contains the C++ source code and cmake file.
- `/src` - Contains the .net source code.
- `/test` - Contains the .net test source code.
- `Dockerfile` - The Docker file describes the setup of your docker container with all pre-requisites to build C++ code for linux and run .net tests.

Hypar functions run on Amazon Lambda, which run Linux docker containers. Your C++ must be compiled for Linux in order to be compatible with Lambda. In this example we provide a Docker container using the Amazon Linux 2 image (the same used by Amazon to run Lambda), in which your code can be compiled, and your wrapper can be tested.

## Building the Container
```
docker build . -t hypar-cpp
```

## Running the Container
The following command will run the docker container interactively and bind the function directory to the `/function` directory in the container. If successful, you'll be presented with a command prompt running inside the container from which you can run commands.
```
docker run -it --mount src="$(pwd)",target=/function,type=bind hypar-cpp
```

|Input Name|Type|Description|
|---|---|---|
|Length|number|The Length.|
|Width|number|The Width.|


<br>

|Output Name|Type|Description|
|---|---|---|
|Volume|Number|The volume.|

