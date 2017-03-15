using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asm.Apolo.Dom.Entities;
using Asm.Apolo.Dom.Repositories;

namespace Asm.Infra.Test
{

    public static class UtilitariosBase
    {
        private static readonly Random Random = new Random();
        public static double RandomNumberDecimalBetween(double minValue, double maxValue)
        {
            var next = Random.NextDouble();
            return minValue + (next * (maxValue - minValue));
        }
        public static double RandomNumberDecimalSeedBetween(double minValue, double maxValue)
        {
            var ran = new Random(Guid.NewGuid().GetHashCode());
            var next = ran.NextDouble();
            return minValue + (next * (maxValue - minValue));
        }
        public static int RandomNumberIntegerBetween(int minValue, int maxValue)
        {
            var next = Random.Next(minValue, maxValue);
            return next;
        }
        public static int RandomNumberIntegerSeedBetween(int minValue, int maxValue)
        {
            var ran = new Random(Guid.NewGuid().GetHashCode());
            var next = ran.Next();
            return minValue + (next * (maxValue - minValue));
        }
        public static bool RandomBoolNumber()
        {
            return (Random.Next(0, 1) > 0);
        }
        public static string NewGuid()
        {
            return Guid.NewGuid().ToString();
        }
        public static Guid GetGuid()
        {
            return Guid.NewGuid();
        }

        #region "Para Entidades con Llave Identity"


        private static long _lastCountId;
        private static readonly Dictionary<Type, IComparable> MainIdCount = new Dictionary<Type, IComparable>();

        public static IComparable NextLongId<TEntidad, TId, TRepo>(Func<TRepo> getRepoAction)
            where TEntidad : Entity<TId>
            where TId : IEquatable<TId>, IComparable<TId>
            where TRepo : IRepository<TEntidad>
        {
            long count = 0;
            if (typeof(TId) == typeof(string))
                return Guid.NewGuid().ToString();
            if (typeof(TId) == typeof(long) || typeof(TId) == typeof(int))
            {
                var nElements = 0;
                var last = getRepoAction.Invoke()
                            .GetPage(f => f.Id, 1, 1);
                count = MainIdCount.ContainsKey(typeof(TEntidad)) ? (long)MainIdCount[typeof(TEntidad)] : 0;

                if (count == 0)
                {
                    if (last != null)
                        count = nElements + 1;
                    else
                        count = 1;
                }
                else
                    count++;
                if (count <= _lastCountId)
                {
                    _lastCountId++;
                    count = _lastCountId;
                }
                else
                    _lastCountId = count;

                MainIdCount[typeof(TEntidad)] = count;

            }
            else
                throw new Exception("Solo se admiten tipos int, long y String");

            return count;
        }

        #endregion

    }
}
