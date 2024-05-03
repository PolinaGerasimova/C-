using System;
using System.Linq;


namespace func_rocket
{
    public class ForcesTask
    {
        /// <summary>
        /// Создает делегат, возвращающий по ракете вектор силы тяги двигателей этой ракеты.
        /// Сила тяги направлена вдоль ракеты и равна по модулю forceValue.
        /// </summary>
        public static RocketForce GetThrustForce(double forceValue) =>
            rocket => new Vector(forceValue * Math.Cos(rocket.Direction), forceValue * Math.Sin(rocket.Direction));

        /// <summary>
        /// Преобразует делегат силы гравитации, в делегат силы, действующей на ракету
        /// </summary>
        public static RocketForce ConvertGravityToForce(Gravity gravity, Vector spaceSize) =>
            rocket => gravity(spaceSize, rocket.Location);

        /// <summary>
        /// Суммирует все переданные силы, действующие на ракету, и возвращает суммарную силу.
        /// </summary>
        public static RocketForce Sum(params RocketForce[] forces) =>
            rocket => forces.Aggregate(Vector.Zero, (currentSum, force) => currentSum + force(rocket));
    }
}