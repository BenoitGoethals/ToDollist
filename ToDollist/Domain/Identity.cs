﻿namespace ToDollist.Domain
{
    public abstract class Identity
    {
        public int Id { get; set; }

        protected bool Equals(Identity other)
        {
            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Identity) obj);
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }
}