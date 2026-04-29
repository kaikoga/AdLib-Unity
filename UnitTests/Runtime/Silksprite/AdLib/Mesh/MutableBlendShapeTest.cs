using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;

namespace Silksprite.AdLib.Mesh
{
    public class MutableBlendShapeTest
    {
        public static IEnumerable<(float[] before, float[] frames, float[] after)> AddSource()
        {
            yield return (new[] { 0f }, new[] { 0f }, new[] { 0f } );
            yield return (new[] { 0f }, new[] { 1f }, new[] { 0f, 1f } );
            yield return (new[] { 0f }, new[] { 1f }, new[] { 0f, 1f } );
            yield return (new[] { 0f }, new[] { 1f, 2f }, new[] { 0f, 1f, 2f } );
            yield return (new[] { 0f }, new[] { 1f, 2f }, new[] { 0f, 1f, 2f } );
        }

        [Test]
        public void TestAdd([ValueSource(nameof(AddSource))](float[] before, float[] frames, float[] after)v)
        {
            var mbs = BlendShapeFixture(v.before);
            var mbs2 = BlendShapeFixture(v.frames);
            mbs.Add(mbs2);
            AssertBlendShape(mbs, v.after);
        }

        public static IEnumerable<(float[] frames, float weight, float value)> GetStateSource()
        {
            yield return (new[] { 1f }, -1f, -1f );
            yield return (new[] { 1f }, 0f, 0f );
            yield return (new[] { 1f }, 0.5f, 0.5f );
            yield return (new[] { 1f }, 1f, 1f );
            yield return (new[] { 1f }, 2f, 2f );
            yield return (new[] { 0f, 1f }, -1f, -1f );
            yield return (new[] { 0f, 1f }, 0f, 0f );
            yield return (new[] { 0f, 1f }, 0.5f, 0.5f );
            yield return (new[] { 0f, 1f }, 1f, 1f );
            yield return (new[] { 0f, 1f }, 2f, 2f );
            yield return (new[] { 1f, 2f }, -1f, -1f );
            yield return (new[] { 1f, 2f }, 0f, 0f );
            yield return (new[] { 1f, 2f }, 1f, 1f );
            yield return (new[] { 1f, 2f }, 2f, 2f );
            yield return (new[] { 1f, 2f }, 3f, 3f );
        }

        [Test]
        public void TestGetState([ValueSource(nameof(GetStateSource))](float[] frames, float weight, float value) v)
        {
            var mbs = BlendShapeFixture(v.frames);
            var state = mbs.GetState(v.weight);
            AssertBlendShapeState(state, v.value);
        }

        static MutableBlendShape BlendShapeFixture(params float[] frameWeights) =>
            new MutableBlendShape("")
            {
                Frames = frameWeights.Select(FrameFixture)
            };

        static MutableBlendShapeFrame FrameFixture(float frameWeight) =>
            new MutableBlendShapeFrame(frameWeight,
                new[] { Vector3.one * frameWeight },
                new[] { Vector3.one * frameWeight },
                new[] { Vector3.one * frameWeight });

        static void AssertBlendShape(MutableBlendShape blendShape, params float[] frameWeights)
        {
            var frames = blendShape.Frames.ToArray();
            Assert.That(frames, Has.Length.EqualTo(frameWeights.Length));
            for (var i = 0; i < frames.Length; i++)
            {
                AssertBlendShapeFrame(frames[i], frameWeights[i]);
            }
        }

        static void AssertBlendShapeState(MutableBlendShapeState state, float frameWeight)
        {
            var v = Vector3.one * frameWeight;
            Assert.That(state.DeltaVertices(), Is.All.EqualTo(v));
            Assert.That(state.DeltaNormals(), Is.All.EqualTo(v));
            Assert.That(state.DeltaTangents(), Is.All.EqualTo(v));
        }

        static void AssertBlendShapeFrame(MutableBlendShapeFrame frame, float frameWeight)
        {
            var v = new [] { Vector3.one * frameWeight };
            Assert.That(frame.FrameWeight, Is.EqualTo(frameWeight));
            // Assert.That(frame.DeltaVertices, Is.EqualTo(v));
            // Assert.That(frame.DeltaNormals, Is.EqualTo(v));
            // Assert.That(frame.DeltaTangents, Is.EqualTo(v));
        }
    }
}