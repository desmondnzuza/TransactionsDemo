using System.ComponentModel.DataAnnotations;

namespace IS.Transactions.Demo.Core.Model
{
    public class Person
    {
        [Key]
        public int Code { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }        
        public string IdNumber { get; set; }
        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", this.Name, this.Surname);
            }
        }
    }
}
