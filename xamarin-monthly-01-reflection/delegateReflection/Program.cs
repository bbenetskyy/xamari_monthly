﻿using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.InteropServices;
using BenchmarkDotNet.Jobs;
using Sigil;

namespace delegateReflection
{

    public class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<ReflectionTestBench>();
        }
    }

    public class MyObject
    {
        private int PrivateGetNumber() => 69420;
        
        public int PublicGetNumber() => 69420;
    }

    [MemoryDiagnoser]
    public class ReflectionTestBench
    {
        #region Setup

        private MyObject _myObject;
        private object _mySecretClass;

        [GlobalSetup]
        public void Setup()
        {
            _myObject = new MyObject();
            _mySecretClass = Activator.CreateInstance(SecretClassType);
        }

        #endregion

        #region Direct Call

        [Benchmark]
        public int DirectCall()
        {
            var result = _myObject.PublicGetNumber();
            return result;
        }

        #endregion

        #region Reflection Classic

        [Benchmark]
        public int ReflectionClassic()
        {
            var methodInfo = typeof(MyObject).GetMethod("PrivateGetNumber", BindingFlags.NonPublic | BindingFlags.Instance);

            var result = (int)methodInfo.Invoke(_myObject, null);
            return result;
        }

        #endregion

        #region Reflection Classic Cached Info

        private static readonly MethodInfo CachedInfo = typeof(MyObject).GetMethod("PrivateGetNumber", BindingFlags.NonPublic | BindingFlags.Instance);

        [Benchmark]
        public int ReflectionCachedInfo()
        {
            var result = (int)CachedInfo.Invoke(_myObject, null);
            return result;
        }

        #endregion

        #region Compiled Delegate

        private static readonly Func<MyObject, int> CompiledDelegate = (Func<MyObject, int>)Delegate.CreateDelegate(typeof(Func<MyObject, int>), CachedInfo);
        
        [Benchmark]
        public int ReflectionCompiledDelegate()
        {
            var result = CompiledDelegate(_myObject);
            return result;
        }

        #endregion

        #region Emitted IL

        private static readonly Type SecretClassType = Type.GetType("SomeNuget.Internals.SecretClass, SomeNuget");

        private static readonly MethodInfo PrivateMethodInfo =
            SecretClassType.GetMethod("GetNumber", BindingFlags.Instance | BindingFlags.NonPublic);

        private static readonly Emit<Func<object, int>> GetMethodEmitter =
            Emit<Func<object, int>>
                .NewDynamicMethod("GetNumberOfSecretClass")
                .LoadArgument(0)
                .CastClass(SecretClassType)
                .Call(PrivateMethodInfo)
                .Return();
        
        //Emits IL code that is effectively a method of a following signature
        /*
            public int GetNumberOfSecretClass(object input)
            {
                return ((SecretClassType)input).GetNumber();
            }
        */
        private static readonly Func<object, int> GetMethodEmittedDelegate =
            GetMethodEmitter.CreateDelegate();

        [Benchmark]
        public int EmittedIlVersion()
        {
            return GetMethodEmittedDelegate(_mySecretClass);
        }

        #endregion
    }
}



