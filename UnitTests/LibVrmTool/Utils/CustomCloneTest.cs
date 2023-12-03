using System;
using System.Linq;
using LibVRMTool.Utils;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace LibVRMTool
{
    public class CustomCloneTest
    {
        class Obj : ScriptableObject
        {
            public int value;
            public Obj x;
            public Obj y;
        }

        class EmptyCloneObj : CustomClone<Obj>
        {
            protected override void Define(CopyStrategyDescriptor descriptor)
            {
            }
        }

        class ShallowCloneObj : CustomClone<Obj>
        {
            protected override void Define(CopyStrategyDescriptor descriptor)
            {
                descriptor.ShallowCopy<Object>();
            }
        }

        class DeepCloneObj : CustomClone<Obj>
        {
            readonly Action _callback;

            public DeepCloneObj(Action callback) => _callback = callback;

            protected override void Define(CopyStrategyDescriptor descriptor)
            {
                descriptor.DeepCopy<Obj>(postProcess: _ => _callback());
            }
        }

        class CustomCloneObj : CustomClone<Obj>
        {
            protected override void Define(CopyStrategyDescriptor descriptor)
            {
                descriptor.Add(new CustomDeepCopy());
            }

            class CustomDeepCopy : DeepCopy<Obj>
            {
                protected override Obj Instantiate(Object source)
                {
                    var src = (Obj)source;
                    var obj = ObjFixture();
                    obj.value = src.value;
                    obj.x = src.x;
                    obj.y = src.y;
                    return obj;
                }

                protected override void DuplicateFields(Obj target, CustomCloneContext context)
                {
                    target.x = target;
                    target.y = target;
                    target.value *= 2;
                }
            }
        }

        static readonly System.Random SysRandom = new System.Random();

        static Obj ObjFixture()
        {
            var obj = ScriptableObject.CreateInstance<Obj>();
            obj.value = SysRandom.Next() & 0xffffff;
            EditorApplication.delayCall += () => Object.DestroyImmediate(obj);
            return obj;
        }

        [Test]
        public void TestEmptyClone()
        {
            var obj = ObjFixture();
            var a = ObjFixture();
            obj.x = a;

            Assert.Throws<CustomCloneException>(() => new EmptyCloneObj().Clone(obj));
        }

        [Test]
        public void TestShallowClone()
        {
            var obj = ObjFixture();
            var a = ObjFixture();
            obj.x = a;

            var subj = new ShallowCloneObj().Clone(obj);
            var mainAsset = (Obj)subj.mainAsset;

            Assert.That(mainAsset, Is.EqualTo(obj));
            Assert.That(subj.subAssets.Count(), Is.EqualTo(0));
        }

        [Test]
        public void TestDeepClone()
        {
            var obj = ObjFixture();
            var a = ObjFixture();
            obj.x = a;
            obj.y = a;

            var i = 0;
            var subj = new DeepCloneObj(() => i++).Clone(obj);
            var mainAsset = (Obj)subj.mainAsset;

            Assert.That(mainAsset, Is.Not.EqualTo(obj));
            Assert.That(mainAsset.value, Is.EqualTo(obj.value));
            Assert.That(mainAsset.x, Is.Not.EqualTo(a));
            Assert.That(mainAsset.x.value, Is.EqualTo(a.value));
            Assert.That(mainAsset.x, Is.EqualTo(mainAsset.y));
            Assert.That(i, Is.EqualTo(2));
            Assert.That(subj.subAssets.Count(), Is.EqualTo(1));
        }

        [Test]
        public void TestCyclicDeepClone()
        {
            var obj = ObjFixture();
            var a = ObjFixture();
            obj.x = a;
            a.x = obj;

            var i = 0;
            var subj = new DeepCloneObj(() =>
            {
                i++;
                if (i > 10) throw new Exception();
            }).Clone(obj);

            var mainAsset = (Obj)subj.mainAsset;

            Assert.That(mainAsset, Is.Not.EqualTo(obj));
            Assert.That(mainAsset.value, Is.EqualTo(obj.value));
            Assert.That(mainAsset.x, Is.Not.EqualTo(a));
            Assert.That(mainAsset.x.value, Is.EqualTo(a.value));
            Assert.That(mainAsset.x.x, Is.EqualTo(mainAsset));
            Assert.That(i, Is.EqualTo(2));
            Assert.That(subj.subAssets.Count(), Is.EqualTo(1));
        }

        [Test]
        public void TestCustomClone()
        {
            var obj = ObjFixture();
            var a = ObjFixture();
            obj.x = a;
            a.x = obj;

            var subj = new CustomCloneObj().Clone(obj);

            var mainAsset = (Obj)subj.mainAsset;

            Assert.That(mainAsset, Is.Not.EqualTo(obj));
            Assert.That(mainAsset.value, Is.EqualTo(obj.value * 2));
            Assert.That(mainAsset.x, Is.EqualTo(mainAsset));
            Assert.That(subj.subAssets.Count(), Is.EqualTo(0));
        }
    }
}