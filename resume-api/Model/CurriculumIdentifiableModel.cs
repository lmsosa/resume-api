namespace Resume.Api.Model
{
    /// <summary>
    /// Curriculum con propiedad Id
    /// </summary>
    public class CurriculumIdentifiableModel : CurriculumBasicModel
    {
        /// <summary>
        /// Identificador del curriculum
        /// </summary>
        public int Id { get; set; }

    }
}