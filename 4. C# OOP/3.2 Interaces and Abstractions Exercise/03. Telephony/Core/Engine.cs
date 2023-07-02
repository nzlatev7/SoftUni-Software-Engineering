using PersonInfo3.Core.Interfaces;
using PersonInfo;
using System;
using System.Collections.Generic;
using System.Text;
using PersonInfo3.IO.Interfaces;
using PersonInfo3.IO;

namespace PersonInfo3.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string[] phoneNumbers = reader.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string[] websites = reader.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            ICallable phone;

            foreach (var phoneNumber in phoneNumbers)
            {
                if (phoneNumber.Length == 10)
                {
                    phone = new Smartphone();
                }
                else
                {
                    phone = new StationaryPhone();
                }

                try
                {
                    writer.WriteLine(phone.Call(phoneNumber));
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }

            IBrowsable browsable = new Smartphone();

            foreach (var website in websites)
            {
                try
                {
                    writer.WriteLine(browsable.Browse(website));
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
