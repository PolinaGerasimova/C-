using System;
using System.Collections.Generic;

namespace func_rocket
{
    public class LevelsTask
    {
        static readonly Physics standardPhysics = new();

        public static IEnumerable<Level> CreateLevels()
        {
            yield return new Level("Zero",
                new Rocket(new Vector(200, 500), Vector.Zero, -0.5 * Math.PI),
                new Vector(600, 200),
                (size, v) => Vector.Zero, standardPhysics);

            yield return new Level("Heavy",
                new Rocket(new Vector(200, 500), Vector.Zero, -0.5 * Math.PI),
                new Vector(600, 200),
                ForcesTask.ConvertGravityToForce((spaceSize, location) => new Vector(0, 0.9)), standardPhysics);

            yield return new Level("Up",
                new Rocket(new Vector(200, 500), Vector.Zero, -0.5 * Math.PI),
                new Vector(700, 500),
                (spaceSize, location) => new Vector(0, -300 / (location.Y + 300.0)), standardPhysics);

            yield return new Level("WhiteHole",
                new Rocket(new Vector(200, 500), Vector.Zero, -0.5 * Math.PI),
                new Vector(600, 200),
                ForcesTask.ConvertGravityToForce((spaceSize, location) =>
                {
                    var d = (location - spaceSize / 2).Length;
                    var gravityMagnitude = 140 * d / (d * d + 1);
                    return (spaceSize / 2 - location).Normalize() * gravityMagnitude;
                }), standardPhysics);

            yield return new Level("BlackHole",
                new Rocket(new Vector(200, 500), Vector.Zero, -0.5 * Math.PI),
                new Vector(600, 200),
                ForcesTask.ConvertGravityToForce((spaceSize, location) =>
                {
                    var d = (location - (spaceSize / 2 + new Vector(0, 150))).Length;
                    var gravityMagnitude = 300 * d / (d * d + 1);
                    return ((spaceSize / 2 + new Vector(0, 150)) - location).Normalize() * gravityMagnitude;
                }), standardPhysics);

            yield return new Level("BlackAndWhite",
                new Rocket(new Vector(200, 500), Vector.Zero, -0.5 * Math.PI),
                new Vector(600, 200),
                ForcesTask.ConvertGravityToForce((spaceSize, location) =>
                {
                    var whiteHoleGravity = (spaceSize, loc) =>
                    {
                        var d = (loc - spaceSize / 2).Length;
                        var gravityMagnitude = 140 * d / (d * d + 1);
                        return (spaceSize / 2 - loc).Normalize() * gravityMagnitude;
                    };

                    var blackHoleGravity = (spaceSize, loc) =>
                    {
                        var d = (loc - (spaceSize / 2 + new Vector(0, 150))).Length;
                        var gravityMagnitude = 300 * d / (d * d + 1);
                        return ((spaceSize / 2 + new Vector(0, 150)) - loc).Normalize() * gravityMagnitude;
                    };

                    return (whiteHoleGravity(spaceSize, location) + blackHoleGravity(spaceSize, location)) / 2;
                }), standardPhysics);
        }
    }
}