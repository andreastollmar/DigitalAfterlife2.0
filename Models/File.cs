﻿using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalAfterlife2._0.Models
{
    public class File
    {
        public int Id { get; set; }
        public string UploadedFile { get; set; }
        public DateTime DateOfUpload { get; set; }
        public virtual Perished? Perished { get; set; }
        [ForeignKey("Perished")]
        public int PerishedId { get; set; }
    }
}
