using System.ComponentModel.DataAnnotations;

namespace Task2_v2_0_0 {
    public class Customer {
        [Required, StringLength(10)]
        public string Name { get; set; }

        public int Id { get; set; }
    }
}