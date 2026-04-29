using System.Collections.Generic;
using NUnit.Framework;
using AdLib.Reflection.Extensions;
using UnityEngine;

namespace Silksprite.AdLib.Reflection.Extensions
{
    public class TypeExtensionTests
    {
        [Test]
        public void TestSystemTypes()
        {
            Assert.That(typeof(string).GetPrettyTypeName(), Is.EqualTo("string"));
            Assert.That(typeof(string).GetNullGuardedPrettyTypeName(), Is.EqualTo("string?"));

            Assert.That(typeof(int).GetPrettyTypeName(), Is.EqualTo("int"));
            Assert.That(typeof(int?).GetPrettyTypeName(), Is.EqualTo("int?"));
        }
        
        [Test]
        public void TestUnityTypes()
        {
            Assert.That(typeof(GameObject).GetPrettyTypeName(), Is.EqualTo("GameObject"));
            Assert.That(typeof(GameObject).GetNullGuardedPrettyTypeName(), Is.EqualTo("GameObject?"));
        }

        [Test]
        public void TestSystemTypesArray()
        {
            Assert.That(typeof(string[]).GetPrettyTypeName(), Is.EqualTo("string[]"));
            Assert.That(typeof(string[]).GetNullGuardedPrettyTypeName(), Is.EqualTo("string?[]?"));
            Assert.That(typeof(int[]).GetPrettyTypeName(), Is.EqualTo("int[]"));
            Assert.That(typeof(int[]).GetNullGuardedPrettyTypeName(), Is.EqualTo("int[]?"));
        }
        
        [Test]
        public void TestUnityTypesArray()
        {
            Assert.That(typeof(List<GameObject>).GetPrettyTypeName(), Is.EqualTo("List<GameObject>"));
            Assert.That(typeof(List<GameObject>).GetNullGuardedPrettyTypeName(), Is.EqualTo("List<GameObject?>?"));
        }

        [Test]
        public void TestSystemTypesGeneric()
        {
            Assert.That(typeof(List<string>).GetPrettyTypeName(), Is.EqualTo("List<string>"));
            Assert.That(typeof(List<string>).GetNullGuardedPrettyTypeName(), Is.EqualTo("List<string?>?"));
            Assert.That(typeof(List<int>).GetPrettyTypeName(), Is.EqualTo("List<int>"));
            Assert.That(typeof(List<int>).GetNullGuardedPrettyTypeName(), Is.EqualTo("List<int>?"));
        }
        
        [Test]
        public void TestUnityTypesGeneric()
        {
            Assert.That(typeof(List<GameObject>).GetPrettyTypeName(), Is.EqualTo("List<GameObject>"));
            Assert.That(typeof(List<GameObject>).GetNullGuardedPrettyTypeName(), Is.EqualTo("List<GameObject?>?"));
        }
    }
}
