using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace People.Models
{
    [Table("people")]
    public class Person
    {
        // Annotations for Id property
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; } 

        // Annotations for the Name property
        [MaxLength(250), Unique]
        public string Name { get; set; }

    }
}
