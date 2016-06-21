using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HiMVC.Models.Domain
{
    public class Student
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        [Column("Sex")]
        public string SexString {
            get { return Sex.ToString(); }
            private set { Sex = value.ParseEnum<Sex>(); }
        }

        [NotMapped]
        public Sex Sex { get; set; }

        public string Email { get; set; }

        public float GPA { get; set; }

        public string Nationality { get; set; }

        public Lecturer Lecturer { get; set; }

        public IEnumerable<Course> Courses { get; set; }

        public IEnumerable<Book> RecommendedBook { get; set; }

    }

    public static class StringExtensions
    {
        public static T ParseEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }

    public enum Sex
    {
        Male,
        Female
    }
}
