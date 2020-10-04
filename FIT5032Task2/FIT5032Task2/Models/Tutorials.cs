namespace FIT5032Task2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tutorials
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string tutorialTime { get; set; }

        [Required]
        public string Introduction { get; set; }

        [Required]
        public string Difficulty { get; set; }

        [Required]
        public string SuitablePeople { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}
