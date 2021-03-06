﻿using Amplifier;
using AmplifierExamples.Kernels;
using Amplifier.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmplifierExamples
{
    class CompilerExecuteEx : IExample
    {
        public void Execute()
        {
            //Create instance of OpenCL compiler and use device
            var compiler1 = new OpenCLCompiler();
            compiler1.UseDevice(0);

            var compiler2 = new OpenCLCompiler();
            compiler2.UseDevice(1);

            compiler1.CompileKernel(typeof(NNActivationKernels));
            compiler2.CompileKernel(typeof(NNActivationKernels));

            float[] x = new float[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            compiler1.Execute("Sigmoid", x);
            PrintArray(x);

            Console.WriteLine();

            compiler2.Execute("Threshold", x, 0.85f);
            PrintArray(x);
        }

        private void PrintArray(float[] data)
        {
            for(int i=0;i<data.Length;i++)
            {
                Console.Write(data[i] + " ");
            }
        }
    }
}
