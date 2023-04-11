using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace bascicASP.Models
{
    public class Student
    {
        [Key]//make Id is a primary key
        public int Id { get; set; }

        [Required(ErrorMessage ="กรุณาป้อนชื่อนักศึกษา")]
        [DisplayName("ชื่อนักศึกษา")]
        public string Name { get; set; }

        [DisplayName("คะแนนสอบ")]
        [Range(0,100, ErrorMessage ="กรุณาป้อนตัวเลขในช่วง 0-100")]
        public int Score { get; set; }
    }
}
