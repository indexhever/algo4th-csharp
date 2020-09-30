using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class Exercises1Tests
    {
        [Test]
        public void Question1_1_7_a()
        {
            float t = 9.0f;
            while (Mathf.Abs(t - 9.0f / t) > .001f)
                t = (9.0f / t + t) / 2.0f;
            Debug.Log(String.Format("{0, 5}\n", t));
        }

        [Test]
        public void Question1_1_7_b()
        {
            int sum = 0;
            for (int i = 1; i < 1000; i++)
                for (int j = 0; j < i; j++)
                    sum++;
            Debug.Log(sum);
        }

        [Test]
        public void Question1_1_7_c()
        {
            int sum = 0;
            for (int i = 1; i < 1000; i *= 2)
                for (int j = 0; j < 1000; j++)
                    sum++;
            Debug.Log(sum);
        }

        /// <summary>
        /// Write a static method lg() that takes an int value N as argument and returns the largest int not larger than the base-2 logarithm of N. Do not use Math.
        /// Robert, Sedgewick.Algorithms(p. 56). Pearson Education.Edição do Kindle.
        /// </summary>
        [Test]
        public void Question1_1_14()
        {
            int n = 10;
            int expectedLog = (int)Math.Log(n, 2);

            int logResult = Lg(n);
            Debug.Log("Expected log: " + expectedLog);

            Assert.AreEqual(expectedLog, logResult);
        }

        [Test]
        public void Question1_1_15()
        {
            int[] inputArray = { 5, 2, 1, 6, 2, 0 };
            int[] expectedArray = { 1, 1, 2, 0, 0, 1, 1 };
            int histogramSize = 7;

            int[] resultArray = Histogram(inputArray, histogramSize);

            AssertArraysAreEqual(expectedArray, resultArray);
        }

        [Test]
        public void Question1_1_16()
        {
            int n = 6;

            string result = ExR1(n);

            Debug.Log(result);
        }

        // It multiplies a with b
        [TestCase(2, 25, 50)]
        [TestCase(3, 11, 33)]
        [TestCase(4, 11, 44)]
        public void Question1_1_18_a(int a, int b, int expectedResult)
        {
            int result = Mystery_a(a, b);

            Assert.AreEqual(expectedResult, result);
        }

        // I don't know yet what it does. Search answer
        [TestCase(2, 25, 1024)]
        [TestCase(3, 11, 432)]
        public void Question1_1_18_b(int a, int b, int expectedResult)
        {
            int result = Mystery_b(a, b);

            Assert.AreEqual(expectedResult, result);
        }

        private int Mystery_a(int a, int b)
        {
            if (b == 0) return 0;
            if (b % 2 == 0) return Mystery_a(a + a, b / 2);
            return Mystery_a(a + a, b / 2) + a;
        }

        private int Mystery_b(int a, int b)
        {
            if (b == 0) return 1;
            if (b % 2 == 0) return Mystery_b(a + a, b / 2);
            return Mystery_b(a + a, b / 2) * a;
        }

        private static string ExR1(int n)
        {
            if (n <= 0)
                return "";
            return ExR1(n - 3) + n + ExR1(n - 2) + n;
        }

        private int[] Histogram(int[] inputArray, int histogramSize)
        {
            List<int> inputList = inputArray.ToList();
            inputList.Sort();
            int lastInputElement = inputList[inputList.Count - 1];
            //int[] outputArray = new int[lastInputElement + 1];
            int[] outputArray = new int[histogramSize];

            for (int i = 0; i < outputArray.Length; i++)
            {
                outputArray[i] = inputList.FindAll((currentElement) => currentElement == i).Count();
            }

            return outputArray;
        }

        private void AssertArraysAreEqual(int[] expectedArray, int[] resultArray)
        {
            Assert.AreEqual(expectedArray.Length, resultArray.Length);

            for(int i = 0; i < expectedArray.Length; i++)
            {
                Assert.AreEqual(expectedArray[i], resultArray[i]);
            }
        }

        private static int Lg(int n)
        {
            int logResult = 0;
            while (n > 1)
            {
                n /= 2;
                logResult++;
            }

            return logResult;
        }
    }
}
