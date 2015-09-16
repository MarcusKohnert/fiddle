using System;

namespace CSharp
{
    public abstract class Newsletter<T>
    {
        public abstract void Send(T info, Customer customer);
    }

    public class Email : Newsletter<string>
    {
        public override void Send(string info, Customer customer)
        {
            //var email = new Email(info);
            //email.Send();
        }
    }

    public class Fax : Newsletter<int>
    {
        public override void Send(int number, Customer customer)
        {
            //var fax = new Fax(info);
            //fax.Send();
        }
    }

    public class Letter : Newsletter<Tuple<string, string, int>>
    {
        public override void Send(Tuple<string, string, int> info, Customer customer)
        {
            //var letter = new Letter();
            //letter.Send();
        }
    }
}