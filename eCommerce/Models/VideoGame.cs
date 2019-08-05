﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Models
{
    /// <summary>
    /// Represents a video game
    /// </summary>
    public class VideoGame
    {
        /// <summary>
        /// Unique Id number for the game
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The game Title
        /// </summary>
        [Required]
        [StringLength(90)]
        public string Title { get; set; }

        /// <summary>
        /// Official ESRB rating
        /// </summary>
        public string Rating { get; set; }

        /// <summary>
        /// The game description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The retail price for the game
        /// </summary>
        [Range(0.01, 999.99)]
        [DataType(DataType.Currency)]
        // Required by default because double is a value type
        public double Price { get; set; }
    }
}
