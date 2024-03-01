﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Models
{
    public class Student : IStudent
    {
        private string firstName;
        private string lastName;

        public Student(int studentId, string firstName, string lastName)
        {
            Id = studentId;
            FirstName = firstName;
            LastName = lastName;

            CoveredExams = new List<int>();
        }

        public int Id { get; private set; }

        public string FirstName
        {
            get => firstName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }

                firstName = value;
            }
        }

        public string LastName
        {
            get => lastName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }

                lastName = value;
            }
        }

        public IReadOnlyCollection<int> CoveredExams { get; private set; }

        public IUniversity University { get; private set; }

        public void CoverExam(ISubject subject)
        {
            List<int> ids = CoveredExams.ToList();

            ids.Add(subject.Id);

            CoveredExams = ids.AsReadOnly();
        }

        public void JoinUniversity(IUniversity university)
        {
            University = university;
        }
    }
}
