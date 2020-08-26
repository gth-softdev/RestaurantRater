using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestaurantRaterAPI.Models
{
    public class Restaurant
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Rating
        {
            get
            {
                // Calculate a total average score based on Ratings
                double totalAverageRating = 0;
                foreach (var rating in Ratings)
                {
                    totalAverageRating += rating.AverageRating;
                }
                return (Ratings.Count > 0) ? totalAverageRating / Ratings.Count : 0;
            }
        }

        //average food rating
        public double FoodRating
        {
            get
            {
                double foodRating = 0;
                foreach (var rating in Ratings)
                {
                    foodRating += rating.FoodScore;
                }
                return (Ratings.Count > 0) ? foodRating / Ratings.Count : 0;
            }
        }


        // average environment rating
        public double EnviroRating
        {
            get
            {
                double enviroRating = 0;
                foreach (var rating in Ratings)
                {
                    enviroRating += rating.EnvironmentScore;
                }
                return (Ratings.Count > 0) ? enviroRating / Ratings.Count : 0;
            }
        }

        //avergae cleanliness rating
        public double CleanRating
        {
            get
            {
                double cleanRating = 0;
                foreach (var rating in Ratings)
                {
                    cleanRating += rating.CleanlinessScore;
                }
                return (Ratings.Count > 0) ? cleanRating / Ratings.Count : 0;
            }
        }

        public bool IsRecommended => Rating > 8.5;

        // All of the assoceiated Rating objects from the database, based on the foreign key relationship
        public virtual List<Rating> Ratings { get; set; } = new List<Rating>();
    }
}