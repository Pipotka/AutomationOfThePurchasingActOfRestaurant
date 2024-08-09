namespace AutomationOfThePurchasingActOfRestaurant.Models
{
    /// <summary>
    /// Специалист
    /// </summary>
    public class Specialist : Human
    {
        /// <summary>
        /// Должность
        /// </summary>
        public string Post;
        
        /// <summary>
        /// Конструктор специалиста
        /// </summary>
        /// <param name="post"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="patronymic"></param>
        public Specialist(string post, string firstName, string lastName,
            string? patronymic = null) : base(firstName, lastName, patronymic)
        {
            Post = post;
        }
    }
}
