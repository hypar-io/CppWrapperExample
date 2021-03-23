# Configure our Required Version
cmake_minimum_required(VERSION 3.0)

# Define the name of our project
project(hello-cpp)

# Define the output library to be a shared file (.so or .dll) and output it as "(lib)hello-cpp.so"
add_library(hello-cpp SHARED HelloWorld.cpp HelloWorld.h)