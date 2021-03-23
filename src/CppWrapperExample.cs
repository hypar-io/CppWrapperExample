using Elements;
using Elements.Geometry;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace CppWrapperExample
{
    public static class CppWrapperExample
    {
        [DllImport(@"libhello-cpp.so")]
        public static extern void PrintHelloWorld();

        /// <summary>
        /// The CppWrapperExample function.
        /// </summary>
        /// <param name="model">The input model.</param>
        /// <param name="input">The arguments to the execution.</param>
        /// <returns>A CppWrapperExampleOutputs instance containing computed results and the model with any new elements.</returns>
        public static CppWrapperExampleOutputs Execute(Dictionary<string, Model> inputModels, CppWrapperExampleInputs input)
        {
            /// Your code here.
            var height = 1.0;
            var volume = input.Length * input.Width * height;
            var output = new CppWrapperExampleOutputs(volume);
            var rectangle = Polygon.Rectangle(input.Length, input.Width);
            var mass = new Mass(rectangle, height);
            output.Model.AddElement(mass);

            // Call our wrapped method
            PrintHelloWorld();

            return output;
        }
    }
}