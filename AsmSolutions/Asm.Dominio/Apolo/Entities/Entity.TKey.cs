using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asm.Dominio.Apolo.Entities
{
    public abstract class Entity<TKey> : IEntity<TKey>
    {
        private const int HashMultiplier = 31;

        protected Entity()
        {
            this.CreatedDate = DateTime.UtcNow;
            this.ModifiedDate = DateTime.UtcNow;
            this.IsActive = true;
            this.IsDeleted = false;
        }
        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public DateTime? DeletedDate { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }
        public override bool Equals(object obj)
        {
            if (!(obj is Entity<TKey>))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            var other = (Entity<TKey>)obj;
            if (IsTransient() && other.IsTransient())
            {
                return false;
            }
            var typeOfThis = GetType();
            var typeOfOther = other.GetType();
            if (!typeOfThis.IsAssignableFrom(typeOfOther) && !typeOfOther.IsAssignableFrom(typeOfThis))
            {
                return false;
            }

            return Id.Equals(other.Id);
        }

        private int? cachedHashcode;
        
        public virtual TKey Id { get; set; }
        public virtual bool IsTransient()
        {
            return this.Id == null || this.Id.Equals(default(TKey));
        }

        public override int GetHashCode()
        {
            if (this.cachedHashcode.HasValue)
            {
                return this.cachedHashcode.Value;
            }

            if (this.IsTransient())
            {
                this.cachedHashcode = base.GetHashCode();
            }
            else
            {
                unchecked
                {
                    var hashCode = this.GetType().GetHashCode();
                    this.cachedHashcode = (hashCode * HashMultiplier) ^ this.Id.GetHashCode();
                }
            }

            return this.cachedHashcode.Value;
        }
        public static bool operator ==(Entity<TKey> left, Entity<TKey> right)
        {
            return Equals(left, null) ? Equals(right, null) : left.Equals(right);
        }

        public static bool operator !=(Entity<TKey> left, Entity<TKey> right)
        {
            return !(left == right);
        }
        public override string ToString()
        {
            return $"[ Name:{GetType().Name}, Id:{Id}]";
        }

    }
}
