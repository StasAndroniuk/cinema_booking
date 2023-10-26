using System.ComponentModel.DataAnnotations;


namespace CinemaBooking.Contract.Api.Requests
{
    public class UpdateMovieRequest
    {
        /// <summary>
        /// Movie name
        /// </summary>
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(255)]
        public string Name { get; set; }

        /// <summary>
        /// Movie description.
        /// </summary>
        [Required(ErrorMessage = "Description is required")]
        [MaxLength(255)]
        public string Description { get; set; }

        /// <summary>
        /// Movie diration in minutes.
        /// </summary>
        [Required(ErrorMessage = "Duration is required")]
        [Range(1, ushort.MaxValue)]
        public ushort Duration { get; set; }

        /// <summary>
        /// Movie genre.
        /// </summary>
        [Required(ErrorMessage = "Genre is required")]
        public string Genre { get; set; }
    }
}
