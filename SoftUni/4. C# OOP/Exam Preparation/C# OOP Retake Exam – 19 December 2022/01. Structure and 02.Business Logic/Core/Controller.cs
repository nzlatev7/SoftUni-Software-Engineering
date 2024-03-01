using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Core.Contracts;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Core
{
    public class Controller : IController
    {
        private SubjectRepository subjects;
        private StudentRepository students;
        private UniversityRepository universities;

        public Controller()
        {
            subjects = new SubjectRepository();
            students = new StudentRepository();
            universities = new UniversityRepository();
        }

        public string AddStudent(string firstName, string lastName)
        {
            IStudent student;

            if (students.Models.Any(x => x.FirstName == firstName && x.LastName == lastName))
            {
                return string.Format(OutputMessages.AlreadyAddedStudent, firstName, lastName);
            }

            student = new Student(students.Models.Count + 1, firstName, lastName);
            students.AddModel(student);

            return string.Format(OutputMessages.StudentAddedSuccessfully, firstName, lastName, students.GetType().Name);
        }

        public string AddSubject(string subjectName, string subjectType)
        {

            if (subjectType != "EconomicalSubject"
                && subjectType != "HumanitySubject"
                && subjectType != "TechnicalSubject")
            {
                return string.Format(OutputMessages.SubjectTypeNotSupported, subjectType);
            }

            if (subjects.Models.Any(x => x.Name == subjectName))
            {
                return string.Format(OutputMessages.AlreadyAddedSubject, subjectName);
            }

            ISubject subject = null;

            switch (subjectType)
            {
                case "EconomicalSubject":
                    subject = new EconomicalSubject(subjects.Models.Count + 1, subjectName);
                    break;
                case "HumanitySubject":
                    subject = new HumanitySubject(subjects.Models.Count + 1, subjectName);
                    break;
                case "TechnicalSubject":
                    subject = new TechnicalSubject(subjects.Models.Count + 1, subjectName);
                    break;              
            }

            subjects.AddModel(subject);

            return string.Format(OutputMessages.SubjectAddedSuccessfully, subjectType, subjectName, subjects.GetType().Name);
        }      

        public string AddUniversity(string universityName, string category, int capacity, List<string> requiredSubjects)
        {   
            
            if (universities.Models.Any(x => x.Name == universityName))
            {
                return string.Format(OutputMessages.AlreadyAddedUniversity, universityName);
            }

            IUniversity university;

            List<int> subjectsForUni = subjects.Models
                .Where(x => requiredSubjects.Contains(x.Name))
                .Select(x => x.Id)
                .ToList();

            university = new University(universities.Models.Count + 1, universityName, category, capacity, subjectsForUni);

            universities.AddModel(university);

            return string.Format(OutputMessages.UniversityAddedSuccessfully, universityName, universities.GetType().Name);
        }

        public string ApplyToUniversity(string studentName, string universityName)
        {
            string[] data = studentName.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string firstName = data[0];
            string lastName = data[1];

            var student = students.Models.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
            var university = universities.Models.FirstOrDefault(x => x.Name == universityName);

            if (student == null)
            {
                return string.Format(OutputMessages.StudentNotRegitered, firstName, lastName);
            }

            if (university == null)
            {
                return string.Format(OutputMessages.UniversityNotRegitered, universityName);
            }

            foreach (var subjectId in university.RequiredSubjects)
            {
                if (!student.CoveredExams.Contains(subjectId))
                {
                    return string.Format(OutputMessages.StudentHasToCoverExams, studentName, universityName);
                }
            }

            if (student.University != null && student.University.Name == university.Name)
            {
                return string.Format(OutputMessages.StudentAlreadyJoined, firstName, lastName, universityName);
            }

            student.JoinUniversity(university);

            return string.Format(OutputMessages.StudentSuccessfullyJoined, firstName, lastName, universityName);
        }

        public string TakeExam(int studentId, int subjectId)
        {
            var student = students.Models.FirstOrDefault(x => x.Id == studentId);
            var subject = subjects.Models.FirstOrDefault(x => x.Id == subjectId);

            if (student == null)
            {
                return OutputMessages.InvalidStudentId;
            }

            if (subject == null)
            {
                return OutputMessages.InvalidSubjectId;
            }

            if (student.CoveredExams.Contains(subjectId))
            {
                return string.Format(OutputMessages.StudentAlreadyCoveredThatExam, 
                    student.FirstName, student.LastName, subject.Name);
            }

            student.CoverExam(subject);

            return string.Format(OutputMessages.StudentSuccessfullyCoveredExam,
                    student.FirstName, student.LastName, subject.Name);
        }

        public string UniversityReport(int universityId)
        {
            var university = universities.Models.FirstOrDefault(x => x.Id == universityId);

            StringBuilder report = new StringBuilder();

            report.AppendLine($"*** {university.Name} ***");
            report.AppendLine($"Profile: {university.Category}");

            int admitted = students.Models
                .Where(x => x.University != null && x.University.Name == university.Name)
                .ToList()
                .Count;

            report.AppendLine($"Students admitted: {admitted}");
            report.AppendLine($"University vacancy: {university.Capacity - admitted}");

            return report.ToString().TrimEnd();
        }
    }
}
