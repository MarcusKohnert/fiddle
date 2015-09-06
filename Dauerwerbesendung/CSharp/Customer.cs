namespace CSharp
{
    using System;

    class Customer : IEquatable<Customer>
    {
        public Customer(string firstname, string lastname)
        {
            this.Firstname = firstname;
            this.Lastname = lastname;
        }

        public string Firstname { get; private set; }

        public string Lastname { get; private set; }

        public bool Equals(Customer other)
        {
            if (other == null) return false;

            return this.Firstname == other.Firstname &&
                   this.Lastname == other.Lastname;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            var other = obj as Customer;
            if (other == null) return false;

            return this.Equals(other);
        }

        public override int GetHashCode()
        {
            return this.Firstname.GetHashCode() ^
                   this.Lastname.GetHashCode();
        }

        public static bool operator ==(Customer customer1, Customer customer2)
        {
            return customer1.Equals(customer2);
        }

        public static bool operator !=(Customer customer1, Customer customer2)
        {
            return customer1.Equals(customer2);
        }
    }
}